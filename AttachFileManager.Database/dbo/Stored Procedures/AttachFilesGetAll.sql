-- AttachFiles 테이블에 데이터 조회(페이징 처리) 저장 프로시저
CREATE PROCEDURE [dbo].[AttachFilesGetAll]
    @PageNumber Int = 1,
    @PageSize Int = 10
AS
    Select * From AttachFiles Order By Id Desc
    Offset ((@PageNumber - 1) * @PageSize) Rows Fetch Next @PageSize Rows Only;
Go
