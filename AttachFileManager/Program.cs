using All;
using Hawaso.Standard;
using System;
using System.Collections.Generic;

namespace AttachFileManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("첨부 파일 관리자");

            // 데이터베이스 연결 문자열: Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AttachFileManager;Integrated Security=True;

            // 입력 테스트
            // AddTest();

            // 출력 테스트
            //GetAllTest();
            //Console.WriteLine("----");
            //GetByBoardAndArticleTest();

            // 상세 테스트
            //GetByIdTest();

            // 수정 테스트
            //GetAllTest(); 
            //UpdateByIdTest();
            //GetAllTest();

            // 삭제 테스트
            //RemoveByIdTest();

            // 검색 테스트
            //GetByFileNameTest();

            // 다운수 증가 테스트
            //GetAllTest();
            //UpdateDownCountById();
            //GetAllTest();
        }

        private static void UpdateDownCountById()
        {
            var repo = new AttachFileRepository();
            repo.UpdateDownCountById(1); 
        }

        private static void UpdateByIdTest()
        {
            var repo = new AttachFileRepository();

            var model = new AttachFileModel() { FileName = "Computer.jpg", FileSize = 2345, Id = 1 };

            repo.UpdateById(model.FileName, model.FileSize, model.Id);
        }

        private static void RemoveByIdTest()
        {
            GetAllTest();
            (new AttachFileRepository()).RemoveById(2);
            GetAllTest(); 
        }

        private static void GetByIdTest()
        {
            var file = (new AttachFileRepository()).GetById(2);
            PrintFiles(new List<AttachFileModel>() { file });
        }

        private static void GetByFileNameTest()
        {
            var files = (new AttachFileRepository()).GetByFileName(".jpg");
            PrintFiles(files);
        }

        private static void GetByBoardAndArticleTest()
        {
            var files = (new AttachFileRepository()).GetByBoardAndArticle(4, 1);
            PrintFiles(files);
        }

        private static void GetAllTest()
        {
            var files = (new AttachFileRepository()).GetAll();
            PrintFiles(files);
        }

        private static void PrintFiles(List<AttachFileModel> files)
        {
            foreach (var file in files)
            {
                Console.WriteLine($"{file.Id} => 파일명: {file.FileName}, 파일크기: {file.FileSize}, 다운수: {file.DownCount}");
            }
        }

        private static void AddTest()
        {
            var repo = new AttachFileRepository();

            //var model = new AttachFileModel() { UserId = 5, BoardId = 4, ArticleId = 1, FileName = "Photo.png", FileSize = 1234 };
            var model = new AttachFileModel() { UserId = 5, BoardId = 4, ArticleId = 1, FileName = "Photo.jpg", FileSize = 2345 };

            repo.Add(model);
        }
    }
}
