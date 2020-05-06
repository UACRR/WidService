CREATE TABLE [dbo].[RelSubPublish] (
    [custIdPub]  INT      NOT NULL,
    [custIdSub]  INT      NOT NULL,
    [dateBegin]  DATE     NOT NULL,
    [dateEnd]    DATE     NULL,
    [createDate] DATETIME DEFAULT (getdate()) NULL,
    [modifyDate] DATETIME DEFAULT (getdate()) NULL,
    CONSTRAINT [PK_RELSUBPUBLISH] PRIMARY KEY CLUSTERED ([custIdPub] ASC, [custIdSub] ASC, [dateBegin] ASC),
    CONSTRAINT [FK_RELSUBPU_REFERENCE_RHPUB] FOREIGN KEY ([custIdPub]) REFERENCES [dbo].[RightHolder] ([custId]),
    CONSTRAINT [FK_RELSUBPU_REFERENCE_RHSUB] FOREIGN KEY ([custIdSub]) REFERENCES [dbo].[RightHolder] ([custId])
);


GO

CREATE TRIGGER [dbo].[tu_RelSubPublish]  ON  [dbo].[RelSubPublish]  FOR UPDATE 
 AS BEGIN

   SET NOCOUNT ON;
   update RelSubPublish set modifyDate = getdate() 
      from inserted t1 
      where RelSubPublish.custIdPub = t1.custIdPub 
        and RelSubPublish.custIdSub = t1.custIdSub 
        and  RelSubPublish.dateBegin = t1.dateBegin
   END

