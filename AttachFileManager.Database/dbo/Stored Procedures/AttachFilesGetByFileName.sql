-- 첨부 파일 테이블에서 파일명으로 데이터 조회 
CREATE PROCEDURE [dbo].[AttachFilesGetByFileName]
    @FileName    NVarChar(255) = ''
AS
    -- 동적 쿼리문 사용해서 문자열 조합 후 실행
    Declare @sql NVarChar(Max) 
    Set @sql = '
        Select * From AttachFiles Where 
        FileName Like ''%' + @FileName + '%'' Order By FileName Asc
    '
    -- Print @sql 
    Exec(@sql)
Go
