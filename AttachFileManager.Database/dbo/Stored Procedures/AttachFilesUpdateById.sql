-- 특정 첨부 파일(Id)의 파일명과 파일크기 수정
CREATE PROCEDURE [dbo].[AttachFilesUpdateById]
    @FileName    NVarChar(255) = '',
    @FileSize    Int = 0,        
    @Id Int = 0 
AS
    Update AttachFiles 
    Set 
        FileName = @FileName,
        FileSize = @FileSize
    Where 
        Id = @Id
Go
