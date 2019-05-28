-- 첨부 파일 테이블의 Id 값 단일 레코드 조회
CREATE PROCEDURE [dbo].[AttachFilesGetById]
    @Id Int = 0
AS
    Select * From AttachFiles Where Id = @Id
Go
