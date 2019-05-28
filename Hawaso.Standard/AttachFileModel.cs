using System;

namespace Hawaso.Standard
{
    /// <summary>
    /// AttachFiles 테이블과 일대일로 매핑되는 모델 클래스 
    /// </summary>
    public class AttachFileModel
    {
        /// <summary>
        /// 일련번호
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 사용자 Id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 게시판 Id
        /// </summary>
        public int BoardId { get; set; }

        /// <summary>
        /// 게시글 Id
        /// </summary>
        public int ArticleId { get; set; }

        /// <summary>
        /// 첨부 파일명
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 첨부 파일 크기(Byte)
        /// </summary>
        public int FileSize { get; set; }

        /// <summary>
        /// 다운수
        /// </summary>
        public int DownCount { get; set; }

        /// <summary>
        /// 첨부 파일 등록일 
        /// </summary>
        public DateTimeOffset TimeStamp { get; set; }
    }
}
