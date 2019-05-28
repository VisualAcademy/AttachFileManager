-- 첨부 파일 테이블의 특정 데이터(Id) 삭제
CREATE PROCEDURE [dbo].[AttachFilesRemoveById]
    @Id Int = 0
AS
    Delete AttachFiles Where Id = @Id
Go
