﻿// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

/* OsmiCardsClient.cs -- 
 * Ars Magna project, http://arsmagna.ru
 * -------------------------------------------------------
 * Status: poor
 */

#region Using directives

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CodeJam;

using JetBrains.Annotations;

using MoonSharp.Interpreter;

using Newtonsoft.Json.Linq;

using RestSharp;

#endregion

namespace RestfulIrbis.OsmiCards
{
    /// <summary>
    /// 
    /// </summary>
    [PublicAPI]
    [MoonSharpUserData]
    public class OsmiCardsClient
    {
        #region Properties

        /// <summary>
        /// Connection
        /// </summary>
        [NotNull]
        public RestClient Connection { get; private set; }

        #endregion

        #region Construction

        /// <summary>
        /// Constructor.
        /// </summary>
        public OsmiCardsClient
            (
                [NotNull] string baseUrl,
                [NotNull] string apiId,
                [NotNull] string apiKey
            )
        {
            Code.NotNullNorEmpty(baseUrl, "baseUrl");
            Code.NotNullNorEmpty(apiId, "apiId");
            Code.NotNullNorEmpty(apiKey, "apiKey");

            Connection = new RestClient(baseUrl)
            {
                Authenticator = new DigestAuthenticator
                    (
                        apiId,
                        apiKey
                    )
            };
        }

        #endregion

        #region Private members

        #endregion

        #region Public methods

        /// <summary>
        /// Проверить ранее выданный PIN-код.
        /// </summary>
        public void CheckPinCode()
        {
        }

        /// <summary>
        /// Создать новую карту.
        /// </summary>
        public void CreateCard
            (
                [NotNull] string cardNumber,
                [NotNull] string template
            )
        {
            Code.NotNullNorEmpty(cardNumber, "cardNumber");
            Code.NotNullNorEmpty(template, "template");

            RestRequest request = new RestRequest
                (
                    "/passes/{number}/{template}",
                    Method.POST
                )
            {
                RequestFormat = DataFormat.Json
            };
            request.AddUrlSegment("number", cardNumber);
            request.AddUrlSegment("template", template);

            Connection.Execute(request);
        }

        /// <summary>
        /// Создать новую карту.
        /// </summary>
        public void CreateCard
            (
                [NotNull] string cardNumber,
                [NotNull] string template,
                [NotNull] string jsonText
            )
        {
            Code.NotNullNorEmpty(cardNumber, "cardNumber");
            Code.NotNullNorEmpty(template, "template");
            Code.NotNullNorEmpty(jsonText, "jsonText");

            RestRequest request = new RestRequest
                (
                    "/passes/{number}/{template}",
                    Method.POST
                )
            {
                RequestFormat = DataFormat.Json
            };
            request.AddUrlSegment("number", cardNumber);
            request.AddUrlSegment("template", template);
            request.AddQueryParameter("withValues", "true");
            request.AddParameter
                (
                    "application/json; charset=utf-8",
                    jsonText,
                    ParameterType.RequestBody
                );

            Connection.Execute(request);
        }

        /// <summary>
        /// Создать новый шаблон.
        /// </summary>
        public void CreateTemplate
            (
                string template
            )
        {
        }

        /// <summary>
        /// Удалить карту.
        /// </summary>
        public void DeleteCard
            (
                [NotNull] string cardNumber,
                bool push
            )
        {
            Code.NotNullNorEmpty(cardNumber, "cardNumber");

            string url = "/passes/{number}";
            if (push)
            {
                url += "/push";
            }

            RestRequest request = new RestRequest
                (
                    url,
                    Method.DELETE
                );
            request.AddUrlSegment("number", cardNumber);

            Connection.Execute(request);
        }

        /// <summary>
        /// Запросить информацию по карте.
        /// </summary>
        public OsmiCard GetCardInfo
            (
                [NotNull] string cardNumber
            )
        {
            Code.NotNullNorEmpty(cardNumber, "cardNumber");

            RestRequest request = new RestRequest
                (
                    "/passes/{number}",
                    Method.GET
                );
            request.AddUrlSegment("number", cardNumber);
            IRestResponse response = Connection.Execute(request);
            JObject jObject = JObject.Parse(response.Content);
            OsmiCard result = OsmiCard.FromJObject(jObject);

            return result;
        }

        /// <summary>
        /// Запросить ссылку на загрузку карты.
        /// </summary>
        public string GetCardLink
            (
                [NotNull] string cardNumber
            )
        {
            Code.NotNullNorEmpty(cardNumber, "cardNumber");

            RestRequest request = new RestRequest
                (
                    "/passes/{number}/link",
                    Method.GET
                );
            request.AddUrlSegment("number", cardNumber);
            IRestResponse response = Connection.Execute(request);
            JObject result = JObject.Parse(response.Content);

            return result["link"].Value<string>();
        }

        /// <summary>
        /// Запросить список карт.
        /// </summary>
        public string[] GetCardList()
        {
            RestRequest request = new RestRequest
                (
                    "/passes",
                    Method.GET
                );
            IRestResponse response = Connection.Execute(request);
            JObject result = JObject.Parse(response.Content);

            return result["cards"].Values<string>().ToArray();
        }

        /// <summary>
        /// Запросить общие параметры сервиса.
        /// </summary>
        public JObject GetDefaults()
        {
            RestRequest request = new RestRequest
                (
                    "/defaults/all",
                    Method.GET
                );
            IRestResponse response = Connection.Execute(request);
            JObject result = JObject.Parse(response.Content);

            return result;
        }

        /// <summary>
        /// Запросить список доступных графических файлов.
        /// </summary>
        public OsmiImage[] GetImages()
        {
            RestRequest request = new RestRequest
                (
                    "/images",
                    Method.GET
                );
            IRestResponse response = Connection.Execute(request);
            JObject result = JObject.Parse(response.Content);

            return result["images"].ToObject<OsmiImage[]>();
        }

        /// <summary>
        /// Запросить общую статистику.
        /// </summary>
        public JObject GetStat()
        {
            RestRequest request = new RestRequest
                (
                    "/stats/general",
                    Method.GET
                );
            IRestResponse response = Connection.Execute(request);
            JObject result = JObject.Parse(response.Content);

            return result;
        }

        /// <summary>
        /// Запросить информацию о шаблоне.
        /// </summary>
        public JObject GetTemplateInfo
            (
                [NotNull] string templateName
            )
        {
            Code.NotNullNorEmpty(templateName, "templateName");

            RestRequest request = new RestRequest
                (
                    "/templates/{name}",
                    Method.GET
                );
            request.AddUrlSegment("name", templateName);
            IRestResponse response = Connection.Execute(request);
            JObject result = JObject.Parse(response.Content);

            return result;
        }

        /// <summary>
        /// Запросить список доступных шаблонов.
        /// </summary>
        public string[] GetTemplateList()
        {
            RestRequest request = new RestRequest
                (
                    "/templates",
                    Method.GET
                );
            IRestResponse response = Connection.Execute(request);
            JObject result = JObject.Parse(response.Content);

            return result["templates"].Values<string>().ToArray();
        }

        /// <summary>
        /// Проверить подключение к сервису.
        /// </summary>
        public JObject Ping()
        {
            RestRequest request = new RestRequest
                (
                    "ping",
                    Method.GET
                );
            IRestResponse response = Connection.Execute(request);
            JObject result = JObject.Parse(response.Content);

            return result;
        }

        /// <summary>
        /// Текстовый поиск по содержимому полей карт.
        /// </summary>
        public string[] SearchCards
            (
                [NotNull] string text
            )
        {
            RestRequest request = new RestRequest
                (
                    "/search/passes",
                    Method.POST
                );

            JObject requestJObject = new JObject
            {
                {"text", text}
            };
            request.AddParameter
                (
                    "application/json; charset=utf-8",
                    requestJObject.ToString(),
                    ParameterType.RequestBody
                );

            IRestResponse response = Connection.Execute(request);
            JArray responseArray = JArray.Parse(response.Content);
            List<string> result = new List<string>();
            foreach (JObject element in responseArray.Children())
            {
                result.Add(element["serial"].Value<string>());
            }

            return result.ToArray();
        }

        /// <summary>
        /// Отправить ссылку на загрузку карты по email.
        /// </summary>
        public void SendCardMail
            (
                string cardNumber,
                string message
            )
        {
        }

        /// <summary>
        /// Отправить ссылку на загрузку карты по СМС.
        /// </summary>
        public void SendCardSms
            (
                string cardNumber,
                string message
            )
        {
        }

        /// <summary>
        /// Отправить PIN-код по СМС.
        /// </summary>
        public void SendPinCode
            (
                [NotNull] string phoneNumber
            )
        {
            Code.NotNullNorEmpty(phoneNumber, "phoneNumber");

            RestRequest request = new RestRequest
                (
                    "/activation/sendpin/{phone}",
                    Method.POST
                );

            Connection.Execute(request);
        }

        /// <summary>
        /// Отправить push-сообщение на указанные карты.
        /// </summary>
        public void SendPushMessage
            (
                [NotNull] string[] cardNumbers,
                [NotNull] string messageText
            )
        {
            Code.NotNull(cardNumbers, "cardNumbers");
            Code.NotNullNorEmpty(messageText, "messageText");

            RestRequest request = new RestRequest
                (
                    "/marketing/pushmessage",
                    Method.POST
                )
            {
                RequestFormat = DataFormat.Json
            };

            JObject obj = new JObject();
            obj.Add("serials", new JArray(cardNumbers));
            obj.Add("message", messageText);
            request.AddParameter
                (
                    "application/json; charset=utf-8", 
                    obj.ToString(), 
                    ParameterType.RequestBody
                );

            /* IRestResponse response = */
            Connection.Execute(request);
        }

        /// <summary>
        /// Переместить карту на другой шаблон.
        /// </summary>
        public void SetCardTemplate
            (
                [NotNull] string cardNumber,
                [NotNull] string template,
                bool push
            )
        {
            Code.NotNullNorEmpty(cardNumber, "cardNumber");
            Code.NotNullNorEmpty(template, "template");

            string url = "/passes/move/{number}/{template}";
            if (push)
            {
                url += "/push";
            }

            RestRequest request = new RestRequest
                (
                    url,
                    Method.PUT
                );
            request.AddUrlSegment("number", cardNumber);
            request.AddUrlSegment("template", template);

            Connection.Execute(request);
        }

        /// <summary>
        /// Изменить общие параметры сервиса.
        /// </summary>
        public void SetDefaults
            (
                string newSettings
            )
        {
        }

        /// <summary>
        /// Обновить значения карты.
        /// </summary>
        public void UpdateCard
            (
                [NotNull] string cardNumber,
                [NotNull] string jsonText,
                bool push
            )
        {
            Code.NotNullNorEmpty(cardNumber, "cardNumber");
            Code.NotNullNorEmpty(jsonText, "jsonText");

            string url = "/passes/{number}";
            if (push)
            {
                url += "/push";
            }

            RestRequest request = new RestRequest
                (
                    url,
                    Method.PUT
                )
            {
                RequestFormat = DataFormat.Json
            };
            request.AddUrlSegment("number", cardNumber);
            request.AddParameter
                (
                    "application/json; charset=utf-8",
                    jsonText,
                    ParameterType.RequestBody
                );

            Connection.Execute(request);
        }

        /// <summary>
        /// Обновить значения шаблона.
        /// </summary>
        public void UpdateTemplate
            (
                string template,
                bool push
            )
        {
        }

        #endregion

        #region Object members

        #endregion
    }
}
