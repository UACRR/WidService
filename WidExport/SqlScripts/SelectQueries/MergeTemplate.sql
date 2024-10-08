merge WidSubmGroupWorkCheckList as Target
	using #CheckList as Source
	on Source.ObjId = Target.ObjId
		and Target.WidSubmGroupId = @groupId
 	-- For Inserts
	when not matched by Target then
		insert (
			  WidSubmGroupId
			, ObjId
			, HasOwnAuthor
			, RolesDefined
			, HasNonPublisher
			, AllInIpi
			, PubShare0or100
			, MecShare0or100
			, HasShare
			, NamesApproved
			, PerformersApproved
			, AllIpiCodesValid
		) 
		values (
			  @groupId
			, Source.ObjId
			, Source.HasOwnAuthor
			, Source.RolesDefined
			, Source.HasNonPublisher
			, Source.AllInIpi
			, Source.PubShare0or100
			, Source.MecShare0or100
			, Source.HasShare
			, Source.NamesApproved
			, Source.PerformersApproved
			, Source.AllIpiCodesValid
		)
 	-- For Updates
	when matched then update set
			  Target.HasOwnAuthor		 = Source.HasOwnAuthor		             
			, Target.RolesDefined		 = Source.RolesDefined
			, Target.HasNonPublisher	 = Source.HasNonPublisher
			, Target.AllInIpi			 = Source.AllInIpi
			, Target.PubShare0or100		 = Source.PubShare0or100
			, Target.MecShare0or100		 = Source.MecShare0or100
			, Target.HasShare			 = Source.HasShare
			, Target.NamesApproved		 = Source.NamesApproved
			, Target.PerformersApproved	 = Source.PerformersApproved
			, Target.AllIpiCodesValid	 = Source.AllIpiCodesValid
	;