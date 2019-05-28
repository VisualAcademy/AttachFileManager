-- AttachFiles 테이블에 데이터 입력 저장 프로시저
CREATE PROCEDURE [dbo].[AttachFilesAdd]
    @UserId      Int = 0,          
    @BoardId     Int = 0,          
    @ArticleId   Int = 0,          
    @FileName    NVarChar(255) = '',
    @FileSize    Int = 0              
AS
    Insert Into AttachFiles 
        (UserId, BoardId, ArticleId, FileName, FileSize)
    Values 
        (@UserId, @BoardId, @ArticleId, @FileName, @FileSize)
Go
