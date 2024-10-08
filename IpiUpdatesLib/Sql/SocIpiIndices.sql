use SocIpi;
create nonclustered index idx_IpiAgreement_IpBaseNr    on IpiAgreement(IpBaseNr)
create nonclustered index idx_IpiAgreement_IpAgreeNr   on IpiAgreement(IpAgreeNr) 

create nonclustered index idx_IpiBase_IpBaseNr		   on IpiBase(IpBaseNr)

create nonclustered index idx_IpiName_IpBaseNr		   on IpiName(IpBaseNr) 
create nonclustered index idx_IpiName_IpNameNr		   on IpiName(IpNameNr) 
create nonclustered index idx_IpiName_Name		   on IpiName(Name) 
create nonclustered index idx_IpiName_FstName		   on IpiName(FstName) 

create nonclustered index idx_IpiNameUsage_IpBaseNr	   on IpiNameUsage(IpBaseNr)
create nonclustered index idx_IpiNameUsage_IpNameNr	   on IpiNameUsage(IpNameNr)

create nonclustered index idx_IpiNationality_IpBaseNr  on IpiNationality(IpBaseNr) 

create nonclustered index idx_IpiRemark_IpBaseNr	   on IpiRemark(IpBaseNr)

create nonclustered index idx_IpiStatus_IpBaseNr	   on IpiStatus(IpBaseNr)

create nonclustered index idx_IpiTerritory_IpAgreeNr   on IpiTerritory(IpAgreeNr)  		 

/*

*/