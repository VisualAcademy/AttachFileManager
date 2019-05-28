using Hawaso.Standard;
using System.Collections.Generic;

namespace All
{
    /// <summary>
    /// IAttachFileRepository 인터페이스로 파일 첨부 관리자 관련 API 설계 
    /// </summary>
    public interface IAttachFileRepository
    {
        // 입력
        void Add(AttachFileModel model);

        // 출력
        List<AttachFileModel> GetAll(int pageNumber = 1, int pageSize = 10);

        // 상세
        List<AttachFileModel> GetByBoardAndArticle(int boardId, int articleId);
        AttachFileModel GetById(int id);

        // 수정
        void UpdateById(string fileName, int fileSize, int id);
        void UpdateDownCountById(int id);

        // 삭제
        void RemoveById(int id); 

        // 검색
        List<AttachFileModel> GetByFileName(string fileName);
    }
}
