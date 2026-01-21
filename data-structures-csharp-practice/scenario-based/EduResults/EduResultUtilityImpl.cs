using System.Collections.Generic;


namespace EduResult{
    class EduResultUtilityImpl : IEduResult
    {
        private Dictionary<string,List<Student>> districts;
        List<Student> finalRankList;
        private Random random;

        public EduResultUtilityImpl()
        {
            districts = new Dictionary<string, List<Student>>();
            random = new Random();
        }

        public void AddResult()
        {
            Console.Write($"Add No of Districts: ");
            int noOfDistricts = Convert.ToInt32(Console.ReadLine());
            
            for(int d = 0; d < noOfDistricts; d++)
            {
                districts[$"District-{d+1}"] = new List<Student>();

                Console.Write($"Enter No of Students in district-{d+1}: ");
                int n = Convert.ToInt32(Console.ReadLine());
                

                for(int i = 0; i < n; i++)
                {
                    Student student = new Student();
                    student.Marks = random.Next(35,100);
                    student.District = $"District-{d+1}";

                    districts[$"District-{d+1}"].Add(student);
                }

                districts[$"District-{d+1}"] = MergeSort(districts[$"District-{d+1}"]);
            }

        }

        public void SortResult()
        {
            finalRankList = new List<Student>();

            foreach (List<Student> districtList in districts.Values)
            {
                finalRankList = Merge(finalRankList, districtList);
            }

            Console.WriteLine("Result Sorted Successfully .. ");
        }

        private List<Student> MergeSort(List<Student> students)
        {
            if (students.Count <= 1)
                return students;

            int mid = students.Count / 2;

            List<Student> left = new List<Student>();
            List<Student> right = new List<Student>();

            for (int i = 0; i < mid; i++)
                left.Add(students[i]);

            for (int i = mid; i < students.Count; i++)
                right.Add(students[i]);

            left = MergeSort(left);
            right = MergeSort(right);

            return Merge(left, right);
        }

        private List<Student> Merge(List<Student> left, List<Student> right)
        {
            List<Student> result = new List<Student>();
            int i = 0;
            int j = 0;

            while (i < left.Count && j < right.Count)
            {
                if (left[i].Marks >= right[j].Marks)
                {
                    result.Add(left[i]);
                    i++;
                }
                else
                {
                    result.Add(right[j]);
                    j++;
                }
            }

            while (i < left.Count)
            {
                result.Add(left[i]);
                i++;
            }

            while (j < right.Count)
            {
                result.Add(right[j]);
                j++;
            }

            return result;
        }

        public void ShowRankList()
        {
            if (finalRankList == null || finalRankList.Count == 0)
            {
                Console.WriteLine("No results to display.");
                return;
            }

            Console.WriteLine("\n District Wise Rank List ... ");

            int displayRank = 1;
            int actualRank = 1;

            Console.WriteLine("Rank " + displayRank + " => " + finalRankList[0]);

            for (int i = 1; i < finalRankList.Count; i++)
            {
                actualRank++;

                if (finalRankList[i].Marks != finalRankList[i - 1].Marks)
                {
                    displayRank = actualRank;
                }

                Console.WriteLine("Rank " + displayRank + " => " + finalRankList[i]);
            }
        }

        public void ShowDistrictRankList()
        {
            if (districts.Count == 0)
            {
                Console.WriteLine("No data available.");
                return;
            }

            Console.WriteLine("\n===== DISTRICT WISE RANK LIST =====");

            foreach (KeyValuePair<string, List<Student>> district in districts)
            {
                Console.WriteLine("\nDistrict : " + district.Key);
                Console.WriteLine("----------------------------------");

                List<Student> districtStudents = MergeSort(district.Value);

                int rank = 1;

                for (int i = 0; i < districtStudents.Count; i++)
                {
                    if (i > 0 && districtStudents[i].Marks != districtStudents[i - 1].Marks)
                    {
                        rank++;
                    }

                    Console.WriteLine(
                        "Rank " + rank + " -> " + districtStudents[i]
                    );
                }
            }
        }


    }


}
