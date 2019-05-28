-- AttachFiles 테이블에서 특정 게시판의 특정 아티클에 해당하는 첨부 파일들
CREATE PROCEDURE [dbo].[AttachFilesGetByBoardAndArticle]
    @BoardId Int = 0,
    @ArticleId Int = 0
AS
    Select * From AttachFiles 
    Where BoardId = @BoardId And ArticleId = @ArticleId  
    Order By FileName Asc
Go
