use SocWidSubmitEx
go

begin try
begin tran

-- нмнбкч╙лн опюбнбкюмхй╡б, ына оепек╡й бйкчвюб бя╡у опхвермху дн пюм╡ь оепедюмху рбнп╡б
	exec spRightHoldersUpdate

-- бйкчвю╙лн б онвюрйнбхи яеюмя рбнпх сяо╡ьмн оепедюм╡ б оноепедмэнлс дндюрйс
	exec spCreateInitialSubmission

-- нмнбкч╙лн опюбнбкюмхй╡б, ына оепек╡й бйкчвюб бя╡у опхвермху дн пюм╡ь оепедюмху рбнп╡б
	exec spRightHoldersUpdate

-- пнгьхпч╙лн ╡мтнплюж╡ч онвюрйнбнцн яеюмяс дндюбюммъл г б╡д рбнп╡б, ъй╡ пюм╡ь б дндюрйс оепедюм╡ ме аскх, юке лючрэ йнд ISWC
	exec spInitialImportWorksFromWid

-- гюйпхбю╙лн онвюрйнбхи яеюмя, ына ярбнпхбяъ мнбхи ярюмдюпрмхл вхмнл
	exec spSubmClose

-- нмнбкч╙лн рбнпх ярбнпемнцн яеюмяс
	exec spSubmWorksUpdate

	commit tran
end try
begin catch
	rollback tran
end catch
