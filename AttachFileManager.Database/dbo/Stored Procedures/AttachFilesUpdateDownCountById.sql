-- 특정 첨부 파일(Id)의 다운수 1 증가
CREATE PROCEDURE [dbo].[AttachFilesUpdateDownCountById]
    @Id Int = 0
AS
    Update AttachFiles 
    Set 
        DownCount = DownCount + 1
    Where 
        Id = @Id
Go
