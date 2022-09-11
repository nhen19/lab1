using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Student
    {
        private int id;
        private string name;
        private float avgScore;
        private string falculty;

        public Student(int id, string name, float avgScore, string falculty)
        {
            this.id = id;
            this.name = name;
            this.avgScore = avgScore;
            this.falculty = falculty;
        }
        public Student(Student s)
        {
            this.id = s.id;
            this.name = s.name;
            this.avgScore = s.avgScore;
            this.falculty = s.falculty;
        }
        public Student()
        {
            Random random = new Random();
            this.id = random.Next(1000,9999);
            this.name = TenNgauNhien();
            this.avgScore = (float)(random.NextDouble()*10);
            this.falculty = khoa[random.Next(khoa.Count)];
        }


        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public float AvgScore { get => avgScore; set => avgScore = value; }
        public string Falculty { get => falculty; set => falculty = value; }

        public void input()
        {
            Console.Write("Mã số sinh viên: ");
            Id = int.Parse(Console.ReadLine());
            Console.Write("Họ tên: ");
            Name = Console.ReadLine();
            Console.Write("Khoa : ");
            Falculty = Console.ReadLine();
            Console.Write("Điểm trung bình: ");
            AvgScore = float.Parse(Console.ReadLine());
        }
        public void show()
        {
            Console.WriteLine("MSSV={0,-6} Họ tên: {1,-25} Khoa: {2,-15} Đtb={3:#.#}", Id, Name, Falculty, AvgScore);
        }
        private static List<String> khoa = new List<String>() {"CNTT","Duoc","Quan tri","Luat","Marketing","Ki thuat", "Thu y", "Truyen thong","Nhac","Nha hang", "Du lich", "Ngan hang"};
        private static List<String> ten = new List<String>() {"An","Anh", "Binh", "Chi", "Dinh","Linh", "Lam", "Minh", "Thanh", "Nhan", "Khanh", "Nguyen", "Bao", "Dang"};
        private static List<String> lot = new List<String>() {"Van", "Thi", "Thu", "Ngoc", "Bao", "Nha", "Cong", "Xuan", "Thanh", "The","Quang" ,"Gia", "Thien", "Minh"};
        private static List<String> ho = new List<String>() { "Dang", "Tran", "Ho", "Le", "Dinh", "Luong", "Lam", "Dao", "Trinh", "Ly", "Quach", "Truong", "Mai", "Nguyen", "Ngo", "Bui" };
        public static string TenNgauNhien()
        {
            Random rand = new Random();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(ho[rand.Next(ho.Count)]+" ");
            stringBuilder.Append(lot[rand.Next(lot.Count)]+" ");
            stringBuilder.Append(ten[rand.Next(ten.Count)]);
            return stringBuilder.ToString();
        }
    }
    class Program
    {
        static void SapXepDiemTangDan(List<Student> DSSV)
        {
            List<Student> listSx = DSSV.OrderBy(p => p.AvgScore).ToList();
            outputList(listSx);
        }
        static void TimSV_DiemMaxCNTT(List<Student> DSSV)
        {
            List<Student> listCNTT = DSSV.Where(p => p.Falculty == "CNTT").ToList();
            if (listCNTT.Count == 0) Console.WriteLine("Không có SV khoa CNTT.");
            else
            {
                float MaxCNTT = listCNTT.Max(p => p.AvgScore);
                List<Student> listMaxCNTT = listCNTT.Where(p => p.AvgScore == MaxCNTT).ToList();
                outputList(listMaxCNTT);
            }   
        }
        static void TimSV_ThuocKhoaCNTT(List<Student> DSSV)
        {
            List<Student> listCNTT= (from student in DSSV
                                     where student.Falculty=="CNTT"
                                     select student).ToList();
            //List<Student> listCNTT = DSSV.Where(p => p.Falculty == "CNTT").ToList();
            if (listCNTT.Count == 0) Console.WriteLine("Không có SV khoa CNTT.");
            else outputList(listCNTT);
        }
        static void TimSV_TuDiem5(List<Student> DSSV)
        {
            List<Student> list5 = DSSV.Where(p => p.AvgScore >= 5).ToList()
                                        .OrderBy(p => p.AvgScore).ToList() ;
            if (list5.Count == 0) Console.WriteLine("Không có SV từ 5 điểm trở lên.");
            else outputList(list5);
        }
        static void TimSV_TuDiem5CNTT(List<Student> DSSV)
        {
            List<Student> list5 = DSSV.Where(p => p.AvgScore >= 5 && p.Falculty=="CNTT").ToList()
                                                                .OrderBy(p => p.AvgScore).ToList();
            if (list5.Count == 0) Console.WriteLine("Không có SV từ 5 điểm trở lên thuộc khoa CNTT.");
            else outputList(list5);
        }
        static List<Student> inputList()
        {
            List<Student> students = new List<Student>();
            Console.Write("Mời nhập số lượng sinh viên: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("\n==== Nhập danh sách sinh viên ====");
            for (int i = 0; i < n; i++)
            {
                Student student = new Student();
                Console.WriteLine("\t*Mời nhập sinh viên thứ {0}: ", i + 1);
                student.input();
                students.Add(student);
            }
            return students;
        }
        static List<Student> randList()
        {
            List<Student> students = new List<Student>();
            Console.Write("Mời nhập số lượng sinh viên: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("\n====> Danh sách sinh viên được tạo ngẫu nhiên:");
            for (int i = 0; i < n; i++)
            {
                students.Add(new Student());
                Thread.Sleep(10);
            }
            return students;
        }
        static void outputList(List<Student> list)
        {
            foreach (Student s in list) s.show();
        }
        static void Next()
        {
            Console.WriteLine("\n[ENTER]"); Console.ReadKey();
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            //nhap ds
            //List<Student> DSSV = inputList();
            Console.WriteLine("[HELLO]");
            List<Student> DSSV = randList();Next();
            //xuat ds
            Console.WriteLine("\n==== Xuất danh sách sinh viên ====");
            outputList(DSSV); Next();
            Console.WriteLine("\n==== SV thuộc khoa CNTT ====");
            TimSV_ThuocKhoaCNTT(DSSV); Next();
            Console.WriteLine("\n==== SV có điểm trung bình lớn hơn hoặc bằng 5 ====");
            TimSV_TuDiem5(DSSV); Next();
            Console.WriteLine("\n==== Sắp xếp SV có điểm tăng dần ====");
            SapXepDiemTangDan(DSSV); Next();
            Console.WriteLine("\n==== SV có điểm trung bình lớn hơn hoặc bằng 5 thuộc khoa CNTT ====");
            TimSV_TuDiem5CNTT(DSSV); Next();
            Console.WriteLine("\n==== SV thuộc khoa CNTT có điểm cao nhất ====");
            TimSV_DiemMaxCNTT(DSSV);
            Console.WriteLine("\n[THE END][SEE YOU]"); Console.ReadKey();

        }
    }
}
