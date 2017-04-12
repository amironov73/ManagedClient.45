library Irbis65;

{ Important note about DLL memory management: ShareMem must be the
  first unit in your library's USES clause AND your project's (select
  Project-View Source) USES clause if your DLL exports any procedures or
  functions that pass strings as parameters or function results. This
  applies to all strings passed to and from your DLL--even those that
  are nested in records and classes. ShareMem is the interface unit to
  the BORLNDMM.DLL shared memory manager, which must be deployed along
  with your DLL. To avoid using BORLNDMM.DLL, pass string information
  using PChar or ShortString parameters. }

uses
//  ShareMem,
  SysUtils,
  Classes;

{$R *.res}
{$WARN UNSAFE_CODE OFF}
{$WARN UNSAFE_TYPE OFF}

//
// http://wiki.elnit.org/index.php/IRBIS64.dll
//

// ===========================================================================

// ������� ������������� Space ���������� ������!!!!!!
function IrbisInit: integer; external 'IRBIS64.dll' name 'Irbisinit';

// ������ ��������� ��� �������� ������ � ������������ ������
// irbisclosemst, irbiscloseterm
function IrbisClose
  (
    space: integer
  ): integer; external 'IRBIS64.dll' name 'Irbisclose';

procedure IrbisDLLVersion
  (
    buffer: Pchar;
    bufsize: integer
  ); external 'IRBIS64.dll';
{
// �������� 5 ������ ����� ��
function IrbisInitNewDB
  (
    path: PChar
  ):integer; external 'IRBIS64.dll';

function irbis_uatab_init
  (
    uctab,
    lctab,
    actab,
    aExecDir,
    aDataPath: PChar
  ): integer; external 'IRBIS64.dll';

function irbis_init_DepositPath
  (
    path: PChar
  ): integer; external 'IRBIS64.dll';

function IrbisNewRec
  (
    space,
    shelf: integer
  ): integer; external 'IRBIS64.dll';

function IrbisFldAdd
  (
    space,
    shelf,
    met,
    nf: integer;
    pole: Pchar
  ): integer; external 'IRBIS64.dll';

function Irbis_InitPFT
  (
    space: integer;
    line: PChar
  ): integer; external 'IRBIS64.dll';

function Irbis_Format
  (
    space,
    shelf,
    alt_shelf,
    trm_shelf,
    LwLn: integer;
    FmtExitDLL : PChar
  ): integer; external 'IRBIS64.dll';

// ��������� ������ ���� �� ������-������
// database - ������ ���� �� ������ ���� ��� ����������!!!
function IrbisInitMst
  (
    space: integer;
    database: Pchar;
    numberShelfs: integer
  ): integer; external 'IRBIS64.dll';

// ��������� ��������� ���� �� ������-������
// database - ������ ���� �� ��������� ���� ��� ����������!!!
function IrbisInitTerm
  (
    space: integer;
    database: Pchar
  ): integer;external 'IRBIS64.dll';

function IrbisMaxMfn
  (
    space: integer
  ): integer; external 'IRBIS64.dll';

function IrbisCloseMst
  (
    space: integer
  ): integer; external 'IRBIS64.dll';

function IrbisRecord
  (
    space,
    shelf,
    mfn: integer
  ): integer; external 'IRBIS64.dll';

function IrbisMfn
  (
    space,
    shelf: integer
  ): integer; external 'IRBIS64.dll';

function IrbisNFields
  (
    space,
    shelf: integer
  ): integer; external 'IRBIS64.dll';

// ������ ����� � ����� ����� step ��� ����������
function IrbisReadVersion
  (
    space,
    mfn: integer
  ):integer; external 'IRBIS64.dll';

// ����� �� ������ ����� step �����
function IrbisRecordBack
  (
    space,
    shelf,
    mfn,
    step:integer
  ): integer; external 'IRBIS64.dll';

function IrbisRecLock0
  (
    space,
    shelf,
    mfn: integer
  ): integer; external 'IRBIS64.dll';

function IrbisRecUnLock0
  (
    space,
    mfn:integer
  ): integer; external 'IRBIS64.dll';

function IrbisRecUpdate0
  (
    space,
    shelf,
    keepLock:integer
  ): integer; external 'IRBIS64.dll';

function IrbisRecIfUpdate0
  (
    space,
    shelf,
    mfn:integer
  ): integer; external 'IRBIS64.dll';

function IrbisIsDBLocked
  (
    space: integer
  ): integer; external 'IRBIS64.dll';

// ������ �������������? - ��� ������!!!!!!!! ������ �������� ����� � XRF
function IrbisIsRealyLocked
  (
    space,
    mfn: integer
  ): integer; external 'IRBIS64.dll';

function IrbisIsRealyActualized
  (
    space,
    mfn: integer
  ): integer; external 'IRBIS64.dll';

function IrbisIsLocked
  (
    space,
    shelf: integer
  ): integer; external 'IRBIS64.dll';

function IrbisIsDeleted
  (
    space,
    shelf: integer
  ): integer; external 'IRBIS64.dll';

function IrbisIsActualized
  (
    space,
    shelf: integer
  ): integer; external 'IRBIS64.dll';
}
// ===========================================================================

// ������� ������������� Space ���������� ������!!!!!!
function IrbisInit65: integer; stdcall;
begin
  Result := IrbisInit;
end;

// ������ ��������� ��� �������� ������ � ������������ ������
// irbisclosemst, irbiscloseterm
function IrbisClose65
  (
    space: integer
  ): integer; stdcall;
begin
  Result := IrbisClose(space);
end;

procedure IrbisDllVersion65
  (
    buffer: Pchar;
    bufsize: integer
  ); stdcall;
begin
  IrbisDLLVersion(buffer, bufsize);
end;
{
// �������� 5 ������ ����� ��
function IrbisInitNewDB65
  (
    path: PChar
  ):integer; stdcall;
begin
  Result := IrbisInitNewDB(path);
end;

function irbis_uatab_init65
  (
    uctab,
    lctab,
    actab,
    aExecDir,
    aDataPath: PChar
  ): integer; stdcall;
begin
  Result := irbis_uatab_init(uctab, lctab, actab, aExecDir, aDataPath);
end;

function irbis_init_DepositPath65
  (
    path: PChar
  ): integer; stdcall;
begin
  Result := irbis_init_DepositPath(path);
end;

function IrbisNewRec65
  (
    space,
    shelf: integer
  ): integer; stdcall;
begin
  Result := IrbisNewRec(space, shelf);
end;

function IrbisFldAdd65
  (
    space,
    shelf,
    met,
    nf: integer;
    pole: Pchar
  ): integer; stdcall;
begin
  Result := IrbisFldAdd(space, shelf, met, nf, pole);
end;

function Irbis_InitPFT65
  (
    space: integer;
    line: PChar
  ): integer; stdcall;
begin
  Result := Irbis_InitPFT(space, line);
end;

function Irbis_Format65
  (
    space,
    shelf,
    alt_shelf,
    trm_shelf,
    LwLn: integer;
    FmtExitDLL : PChar
  ): integer; stdcall;
begin
  Result := Irbis_Format(space, shelf, alt_shelf, trm_shelf, LwLn, FmtExitDLL);
end;

// ��������� ������ ���� �� ������-������
// database - ������ ���� �� ������ ���� ��� ����������!!!
function IrbisInitMst65
  (
    space: integer;
    database: Pchar;
    numberShelfs: integer
  ): integer; stdcall;
begin
  Result := IrbisInitMst(space, database, numberShelfs);
end;

// ��������� ��������� ���� �� ������-������
// database - ������ ���� �� ��������� ���� ��� ����������!!!
function IrbisInitTerm65
  (
    space: integer;
    database: Pchar
  ): integer; stdcall;
begin
  Result := IrbisInitTerm(space, database);
end;

function IrbisMaxMfn65
  (
    space: integer
  ): integer; stdcall;
begin
  Result := IrbisMaxMfn(space);
end;

function IrbisCloseMst65
  (
    space: integer
  ): integer; stdcall;
begin
  Result := IrbisCloseMst(space);
end;

function IrbisRecord65
  (
    space,
    shelf,
    mfn: integer
  ): integer; stdcall;
begin
  Result := IrbisRecord(space, shelf, mfn);
end;

function IrbisMfn65
  (
    space,
    shelf: integer
  ): integer; stdcall;
begin
  Result := IrbisMfn(space, shelf);
end;

function IrbisNFields65
  (
    space,
    shelf: integer
  ): integer;  stdcall;
begin
  Result := IrbisNFields(space, shelf);
end;

// ������ ����� � ����� ����� step ��� ����������
function IrbisReadVersion65
  (
    space,
    mfn: integer
  ):integer; stdcall;
begin
  Result := IrbisReadVersion(space, mfn);
end;

// ����� �� ������ ����� step �����
function IrbisRecordBack65
  (
    space,
    shelf,
    mfn,
    step:integer
  ): integer; stdcall;
begin
  Result := IrbisRecordBack(space, shelf, mfn, step);
end;

function IrbisRecLock065
  (
    space,
    shelf,
    mfn: integer
  ): integer; stdcall;
begin
  Result := IrbisRecLock0(space, shelf, mfn);
end;

function IrbisRecUnLock065
  (
    space,
    mfn:integer
  ): integer; stdcall;
begin
  Result := IrbisRecUnLock0(space, mfn);
end;

function IrbisRecUpdate065
  (
    space,
    shelf,
    keepLock:integer
  ): integer; stdcall;
begin
  Result := IrbisRecUpdate0(space, shelf, keepLock);
end;

function IrbisRecIfUpdate065
  (
    space,
    shelf,
    mfn:integer
  ): integer; stdcall;
begin
  Result := IrbisRecIfUpdate0(space, shelf, mfn);
end;

function IrbisIsDBLocked65
  (
    space: integer
  ): integer; stdcall;
begin
  Result := IrbisIsDBLocked(space);
end;

// ������ �������������? - ��� ������!!!!!!!! ������ �������� ����� � XRF
function IrbisIsRealyLocked65
  (
    space,
    mfn: integer
  ): integer; stdcall;
begin
  Result := IrbisIsRealyLocked(space, mfn);
end;

function IrbisIsRealyActualized65
  (
    space,
    mfn: integer
  ): integer; stdcall;
begin
  Result := IrbisIsRealyActualized(space, mfn);
end;

function IrbisIsLocked65
  (
    space,
    shelf: integer
  ): integer; stdcall;
begin
  Result := IrbisIsLocked(space, shelf);
end;

function IrbisIsDeleted65
  (
    space,
    shelf: integer
  ): integer; stdcall;
begin
  Result := IrbisIsDeleted(space, shelf);
end;

function IrbisIsActualized65
  (
    space,
    shelf: integer
  ): integer; stdcall;
begin
  Result := IrbisIsActualized(space, shelf);
end;

}

function InteropVersion: integer; stdcall;
begin
  Result := 100;
end;

// ===========================================================================

exports

IrbisInit65 name 'IrbisInit',
IrbisClose65 name 'IrbisClose',
IrbisDllVersion65 name 'IrbisDllVersion',
{
IrbisInitNewDB65 name 'IrbisInitNewDb',
irbis_uatab_init65 name 'IrbisUatabInit',
irbis_init_DepositPath65 name 'IrbisInitDepositPath',
IrbisNewRec65 name 'IrbisNewRec',
IrbisFldAdd65 name 'IrbisFldAdd',
Irbis_InitPFT65 name 'IrbisInitPft',
Irbis_Format65 name 'IrbisFormat',
IrbisInitMst65 name 'IrbisInitMst',
IrbisInitTerm65 name 'IrbisInitTerm',
IrbisMaxMfn65 name 'IrbisMaxMfn',
IrbisCloseMst65 name 'IrbisCloseMfn',
IrbisRecord65 name 'IrbisRecord',
IrbisMfn65 name 'IrbisMfn',
IrbisNFields65 name 'IrbisNFields',
IrbisReadVersion65 name 'IrbisReadVersion',
IrbisRecordBack65 name 'IrbisRecordBack',
IrbisRecLock065 name 'IrbisRecLock0',
IrbisRecUnLock065 name 'IrbisRecUnlock0',
IrbisRecUpdate065 name 'IrbisRecUpdate0',
IrbisRecIfUpdate065 name 'IrbisRecIfUpdate0',
IrbisIsDBLocked65 name 'IrbisIsDBLocked',
IrbisIsRealyLocked65 name 'IrbisIsReallyLocked',
IrbisIsRealyActualized65 name 'IrbisIsReallyActualized',
IrbisIsLocked65 name 'IrbisIsLocked',
IrbisIsDeleted65 name 'IrbisIsDeleted',
IrbisIsActualized65 name 'IrbisIsActualized',
}
InteropVersion name 'InteropVersion';

// ===========================================================================

begin
end.
