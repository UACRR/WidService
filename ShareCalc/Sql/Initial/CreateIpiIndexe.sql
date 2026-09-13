use SocIpi
go

create nonclustered index pk_IpiTerritory on IpiTerritory (Id);
go

create clustered index idx_IpiTerritory_IpAgreeNr on IpiTerritory (IpAgreeNr);
go

create nonclustered index pk_IpiAgreement on IpiAgreement (Id);
go

create clustered index idx_IpiAgreement_IpBaseNr on IpiAgreement (IpBaseNr);
go

create nonclustered index idx_IpiAgreement_IpAgreeNr on IpiAgreement (IpAgreeNr);
go


