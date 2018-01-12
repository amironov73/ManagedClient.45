﻿// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

/* UniforPlusPlusC.cs -- 
 * Ars Magna project, http://arsmagna.ru
 * -------------------------------------------------------
 * Status: poor
 */

#region Using directives

using AM;
using AM.Text;

using JetBrains.Annotations;

using ManagedIrbis.Client;
using ManagedIrbis.Fields;

#endregion

namespace ManagedIrbis.Pft.Infrastructure.Unifors
{
    //
    // Создана служба ГЛОБАЛЬНЫХ СЧЕТЧИКОВ 
    //
    // Служба ГЛОБАЛЬНЫХ СЧЕТЧИКОВ предназначена для ведения
    // глобальных (т.е. действующих в рамках системы в целом)
    // данных, которые представляют собой строку, содержащую
    // переменную числовую составляющую.
    //
    // Для хранения глобальных счетчиков служит специальная
    // база данных с именем COUNT (зарезервированное имя).
    //
    // Каждая запись базы данных служит для хранения и описания
    // одного глобального счетчика и содержит три обязательных поля:
    //
    // * Индекс глобального счетчика - уникальный идентификатор
    // счетчика (в простейшем случае - номер); метка поля - 1;
    //
    // * Текущее значение глобального счетчика; метка поля - 2;
    //
    // * Шаблон глобального счетчика - определяет структуру (маску)
    // счетчика; метка поля - 3.
    //
    // Шаблон глобального счетчика в общем случае может содержать
    // три части:
    //
    // * Префиксная часть - любой набор символов (кроме символа *),
    // в частном случае может отсутствовать;
    //
    // * Числовая часть - обязательная, обозначается символами *;
    //
    // * Суффиксная часть - любой набор символов (кроме символа *),
    // в частном случае может отсутствовать.
    //
    // Если числовая часть счетчика не имеет фиксированной длины
    // (т.е. не имеет лидирующих нулей), то она обозначается одним
    // символом *. Если числовая часть имеет фиксированную длину
    // (с лидирующими нулями), то она обозначается соответствующим
    // количеством символов *.
    //
    // Примеры шаблонов и соответствующих им значений счетчиков:
    //
    // Шаблон АИ-***/1
    // Значения счетчика: АИ-000/1, АИ-001/1, АИ-100/1 и т.п.
    //
    // Шаблон **** 
    // Значения счетчика: 0000, 0020, 0100, 9999 и т.п.
    //
    // Шаблон С/*
    // Значения счетчика: С/10, С/965, С/10000, С/0 и т.п.
    //
    // Для чтения и изменения значения глобального счетчика
    // служит форматный выход языка форматирования ИРБИС
    // следующего вида: 
    //
    // &uf(‘++C<index>#<value>’) 
    //
    // где: 
    // <index> - индекс глобального счетчика 
    // <value> - управляющая часть, которая может принимать
    // следующие значения: 
    // * пустота (т.е отсутствовать) - в этом случае форматный
    // выход возвращает текущее значение глобального счетчика;
    // * целое число (возможно отрицательное) - в этом случае
    // числовая часть глобального счетчика изменяется
    // на соответствующее значение и форматный выход возвращает
    // новое (измененное) текущее значение глобального счетчика;
    // * конструкция вида !<value> - в этом случае глобальному
    // счетчику (в целом, а не числовой его части) присваивается
    // значение <value> и форматный выход ничего не возвращает;
    // в случае если <value> не указывается (имеет пустое значение)
    // - числовая часть счетчика устанавливается в нулевое значение
    // и форматный выход ничего не возвращает.
    //
    // Формально данный форматный выход можно использовать в любом
    // формате, но практически имеет смысл использовать его ТОЛЬКО
    // в операндах команд глобальной корректировки. Следует понимать,
    // что данный форматный выход (изменяющий текущее значение
    // глобального счетчика) будет отрабатывать при ВСЯКОМ исполнении
    // формата, в котором он содержится (т. е. если формат, содержащий
    // данный форматный выход, отлаживать в Редакторе форматов,
    // то он - форматный выход - будет отрабатывать на текущем
    // документе при ЛЮБОЙ корректировке формата).

    // Пример (разумеется, упрощенный) использования глобальных
    // счетчиков для автоматического формирования идентификатора
    // читателя в зависимости от его категории.
    //
    // Предположим, что есть две категории читателей (значение поля 50)
    // 0 - студенты;
    // 1 - преподаватели.
    //
    // Для студентов необходимо формировать идентификаторы (поле 30) вида:
    // С–nnnnnn (nnnnnn – порядковые номера).
    // А для преподавателей:
    // П–mmmmmm (mmmmmm – порядковые номера)
    // Поступаем следующим образом:
    // 1. В БД COUNT создаем описания двух глобальных счетчиков.
    //
    // Для студентов:
    // #1: 01 
    // #2: C-000000
    // #3: C-******
    //
    // Для преподавателей:
    // #1: 02
    // #2: П-000000
    // #3: П-******
    //
    // 2. В autoin.gbl для БД RDR добавляем следующие строки:
    //
    // ADD
    // 30
    // XXXXXXXXXXXXXXXXXXX
    // if v30='' then if v50='0' then &uf('++C01#1') else if v50='1' then &uf('++C02#1') fi fi fi
    // XXXXXXXXXXXXXXXXXXX
    //
    // Замечания для продвинутых пользователей:
    //
    // Может возникнуть вопрос, почему конструкция
    // &uf(‘++C<index>#!<value>’) устанавливает значение глобального
    // счетчика в целом, а не значение его числовой части.
    // Объяснить это можно на следующем примере.
    // Допустим, мы в Редакторе форматов редактируем формат,
    // который содержит форматный выход, меняющий значение
    // глобального счетчика (с индексом 01).
    // В этом случае возникает проблема: как в процессе отладки
    // (редактирования формата) сохранить НЕИЗМЕННЫМ значение
    // соответствующего глобального счетчика. Сделать это можно,
    // если добавить (в Редакторе форматов) следующие конструкции: 
    //
    // &uf(‘+7W1#’,&uf(‘++C01#’)) ... <редактируемый формат> ... &uf(‘++C01#!’,g1)
    //
    // Здесь в начальной конструкции в глобальной переменной 1
    // запоминается исходное значение глобального счетчика 01,
    // а в конечной конструкции оно восстанавливается.
    //
    // Что же касается установки конкретного значения числовой части
    // глобального счетчика (например, 999), то это можно сделать
    // следующим образом: 
    //
    // &uf(‘++C01#!’), &uf(‘++C01#999’)
    //

    static class UniforPlusPlusC
    {
        #region Public methods

        public static void WorkWithGlobalCounter
            (
                [NotNull] PftContext context,
                [CanBeNull] PftNode node,
                [CanBeNull] string expression
            )
        {
            if (string.IsNullOrEmpty(expression))
            {
                return;
            }

            TextNavigator navigator = new TextNavigator(expression);
            string index = navigator.ReadUntil('#');
            if (string.IsNullOrEmpty(index))
            {
                return;
            }

            IrbisProvider provider = context.Provider;

            // TODO implement INI-file handling
            //string name = provider.GetIniValue("MAIN", "GlobCountNAME", "Count");
            //CounterDatabase database = new CounterDatabase(provider, name);

            CounterDatabase database = new CounterDatabase(provider);
            GlobalCounter counter = database.GetCounter(index);
            if (ReferenceEquals(counter, null))
            {
                return;
            }

            char command = '\0';
            string value = null;
            string output = null;
            if (navigator.ReadChar() == '#')
            {
                if (navigator.PeekChar() == '!')
                {
                    command = navigator.ReadChar();
                }
                value = navigator.GetRemainingText();
            }

            if (command == '!')
            {
                if (string.IsNullOrEmpty(value))
                {
                    counter.NumericValue = 0;
                }
                else
                {
                    counter.Value = value;
                }
                database.UpdateCounter(counter);
            }
            else
            {
                if (!string.IsNullOrEmpty(value))
                {
                    counter.Increment(value.SafeToInt32());
                    database.UpdateCounter(counter);
                }

                output = counter.Value;
            }

            context.WriteAndSetFlag(node, output);
        }

        #endregion
    }
}
