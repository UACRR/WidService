use MediaService

insert Customer(custType, Status, AnkVersion, DateCreate, ModifyDate)
values (3, 0, 1, getdate(), getdate())
declare @CustId int = scope_identity()

insert Company values(@CustId, 0)

insert AnketaCompany(CustId, version, status, Name, ShortName, okpo, TypeVat, JaCountry)
values(@CustId, 1, 0, 'Meta-Facebook', 'Meta', '00000', 1, 804)

insert AgreementMaster(CustId, agrStatus, agrType, version)
values (@custId, 0, 2, 1)
declare @agrId int = scope_identity()

insert Client values (@CustId, null, null)

insert LicenseAgreement(licCode, custId, licStatus, licClass, agrId, licVersion, licMethod)
values (37, @CustId, 0, 0, @agrId, 1, 0)
declare @licId int = scope_identity()

insert LicenseAgrParam(licId, licVersion, LicNum, PeriodCode, LicStatus)
values (@licId, 1, 'OC-16345', 2, 0)
