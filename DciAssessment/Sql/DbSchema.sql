use DciAssessment
go

create table DciRepAssessment (
	  AssessmentId int primary key
	, Name varchar(20)
	, StartDate date
	, EndDate date
	, IsIntegrity bit
	, IsCoverage bit
	, IsConsistency bit
)
go

create table DciRepCatField (
	  FieldName varchar(50) primary key
	, FieldDescription varchar(200)
)
go

create table DciRepCatSociety (
	  SocCde int
	, SourceDb int
	, SocName varchar(60)
	, primary key(SocCde, SourceDb))
go

create table DciRepCatValidation (
	  ValidationId varchar(3) primary key
	, Name varchar(100)
	, Description varchar(1000)
	, Mandatory bit
	, Type char(1)
)
go

create table DciRepCatValidationError (
	  ErrorCode varchar(10) primary key
	, ValidationId varchar(3)
	, FieldName varchar(50)
	, ErrorDescription varchar(200)
	, foreign key (ValidationId) references DciRepCatValidation (ValidationId)
	, foreign key (FieldName) references DciRepCatField(FieldName)
)
go

create table DciRepIntegritySnap (
	  Id int primary key
	, AssessmentId int
	, SocCde int
	, SourceDb int
	, NumDomestic int
	, DomesticOk int
	, NumInternational int
	, InternationalOk int
	, foreign key (AssessmentId) references DciRepAssessment(AssessmentId)
	, foreign key (SocCde, SourceDb) references DciRepCatSociety(SocCde, SourceDb)
)
go

create table DciRepIntegritySnapDetail (
	  SnapshotId int
	, ErrorCode varchar(10)
	, NumWorks int
	, primary key(SnapshotId, ErrorCode)
	, foreign key (SnapshotId) references DciRepIntegritySnap(Id)
	, foreign key (ErrorCode) references DciRepCatValidationError(ErrorCode)
)
go

create table DciRepWorkCatalog (
	  WorkId int primary key
	, SocWorkCde varchar(20)
	, SocCde int
	, SourceDb int
	, Domestic varchar(3)
	, Title varchar(120)
	, Author varchar(136)
	, Iswc varchar(11)
	, IpCheckSum varchar(255)
	, foreign key (SocCde, SourceDb) references DciRepCatSociety(SocCde, SourceDb)
)
go

create table DciRepWork (
	  WorkId int
	, AssessmentId int
	, IntegrityOk char(1)
	, CoverageOk char(1)
	, ConsistencyOk char(1)
	, primary key (WorkId, AssessmentId)
	, foreign key (WorkId) references DciRepWorkCatalog(WorkId)
	, foreign key (AssessmentId) references DciRepAssessment(AssessmentId)
)
go

create table DciRepIntegrityFailure (
	  FailureId int primary key
	, WorkId int
	, AssessmentId int
	, ErrorCode varchar(10)
	, Entity varchar(4000)
	, FieldValue varchar(4000)
	, Parameter1 varchar(4000)
	, Parameter2 varchar(4000)
	, Suggestion varchar(4000)
	, foreign key (WorkId, AssessmentId) references DciRepWork(WorkId, AssessmentId)
	, foreign key (AssessmentId) references DciRepAssessment(AssessmentId)
	, foreign key (ErrorCode) references DciRepCatValidationError(ErrorCode)
)
go
