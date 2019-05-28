// DapperDemo 강의 참조
using Dapper;
using Hawaso.Standard;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace All
{
    public class AttachFileRepository : IAttachFileRepository
    {
        private readonly IDbConnection db;

        public AttachFileRepository()
        {
            db = new SqlConnection("server=(localdb)\\mssqllocaldb;database=AttachFileManager;integrated security=true;");
        }

        /// <summary>
        /// 첨부 파일 정보를 데이터베이스에 저장 
        /// </summary>
        /// <param name="model">AttachFileModel 모델 클래스</param>
        public void Add(AttachFileModel model)
        {
            string sql = "AttachFilesAdd";

            var parameters = new DynamicParameters();

            parameters.Add("@UserId", value: model.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("@BoardId", value: model.BoardId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("@ArticleId", value: model.ArticleId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("@FileName", value: model.FileName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@FileSize", value: model.FileSize, dbType: DbType.Int32, direction: ParameterDirection.Input);

            db.Execute(sql, parameters, commandType: CommandType.StoredProcedure); 
        }

        /// <summary>
        /// 첨부 파일 전체 리스트
        /// </summary>
        /// <param name="pageNumber">페이지 번호</param>
        /// <param name="pageSize">페이지 크기</param>
        /// <returns>첨부 파일 전체 리스트</returns>
        public List<AttachFileModel> GetAll(int pageNumber = 1, int pageSize = 10)
        {
            string sql = "AttachFilesGetAll";

            return db.Query<AttachFileModel>(
                sql, new { PageNumber = pageNumber, PageSize = pageSize }, commandType: CommandType.StoredProcedure).ToList(); 
        }

        /// <summary>
        /// AttachFiles 테이블에서 특정 게시판의 특정 아티클에 해당하는 첨부 파일들
        /// </summary>
        /// <param name="boardId">게시판 Id</param>
        /// <param name="articleId">게시글 Id</param>
        /// <returns>AttachFiles 테이블에서 특정 게시판의 특정 아티클에 해당하는 첨부 파일들</returns>
        public List<AttachFileModel> GetByBoardAndArticle(int boardId, int articleId)
        {
            string sql = "AttachFilesGetByBoardAndArticle";

            var parameters = new DynamicParameters();

            parameters.Add("@BoardId", value: boardId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("@ArticleId", value: articleId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            return db.Query<AttachFileModel>(sql, parameters, commandType: CommandType.StoredProcedure).ToList();
        }

        /// <summary>
        /// 첨부 파일 테이블에서 파일명으로 데이터 조회
        /// </summary>
        /// <param name="fileName">검색할 파일명</param>
        /// <returns>첨부 파일 테이블에서 파일명으로 데이터 조회</returns>
        public List<AttachFileModel> GetByFileName(string fileName)
        {
            string sql = "AttachFilesGetByFileName";

            var parameters = new DynamicParameters();

            parameters.Add("@FileName", value: fileName, dbType: DbType.String, direction: ParameterDirection.Input);

            return db.Query<AttachFileModel>(sql, parameters, commandType: CommandType.StoredProcedure).ToList();
        }

        /// <summary>
        /// 첨부 파일 테이블의 Id 값 단일 레코드 조회
        /// </summary>
        /// <param name="id">첨부 파일 테이블 Id</param>
        /// <returns>첨부 파일 테이블의 Id 값 단일 레코드 조회</returns>
        public AttachFileModel GetById(int id)
        {
            string sql = "AttachFilesGetById";

            return db.Query<AttachFileModel>(sql, new { Id = id }, commandType: CommandType.StoredProcedure).SingleOrDefault();
        }

        /// <summary>
        /// 첨부 파일 테이블의 특정 데이터(Id) 삭제
        /// </summary>
        /// <param name="id">일련번호</param>
        public void RemoveById(int id)
        {
            string sql = "AttachFilesRemoveById";

            db.Execute(sql, new { Id = id }, commandType: CommandType.StoredProcedure);
        }

        /// <summary>
        /// 특정 첨부 파일(Id)의 파일명과 파일크기 수정
        /// </summary>
        /// <param name="fileName">파일명</param>
        /// <param name="fileSize">파일크기</param>
        /// <param name="id">일련번호</param>
        public void UpdateById(string fileName, int fileSize, int id)
        {
            string sql = "AttachFilesUpdateById";

            var parameters = new DynamicParameters();

            parameters.Add("@FileName", value: fileName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@FileSize", value: fileSize, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("@Id", value: id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            db.Execute(sql, parameters, commandType: CommandType.StoredProcedure);
        }

        /// <summary>
        /// 특정 첨부 파일(Id)의 다운수 1 증가
        /// </summary>
        /// <param name="id">일련번호</param>
        public void UpdateDownCountById(int id)
        {
            string sql = "AttachFilesUpdateDownCountById";

            db.Execute(sql, new { Id = id }, commandType: CommandType.StoredProcedure);
        }
    }
}
