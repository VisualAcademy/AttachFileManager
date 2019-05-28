-- 첨부 파일 관리자 
CREATE TABLE [dbo].[AttachFiles]
(
    Id INT NOT NULL PRIMARY KEY Identity(1, 1),             -- 일련번호   
    UserId Int Null,                                        -- 사용자 Id
    BoardId Int Not Null,                                   -- 게시판 테이블 일련번호
    ArticleId Int Not Null,                                 -- 게시판 아티클 일련번호
    FileName NVarChar(255) Null,                            -- 파일명(확장자 포함)
    FileSize Int Null,                                      -- 파일크기
    DownCount Int Default 0,                                -- 다운수
    TimeStamp DateTimeOffset(7) Default(GetDate()) Null		-- 업로드 시간
)
Go
