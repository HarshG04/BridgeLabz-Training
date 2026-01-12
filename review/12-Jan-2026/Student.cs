class Student{
	public string name {get;set;}
	public int age {get;set;}
	public int marks {get;set;}
}

interface IStudent{
	void AddStudent();
	void BubbleSort();	//name wise
	void MergeSort();	//marks wise
}

class StudentUtilityImpl : IStudent{
	
	Student[] students;
	int idx = 0;
	
	public StudentUtilityImpl(int cap){
		students = new Student[cap];
	}
	
	public void AddStudent(){
	
		if(idx>=students.Length){
			Console.WriteLine("Capacity is full");
			return;
		}
		Student s = new Student();
		Console.WriteLine("Enter Name");
		s.name = Console.ReadLine();
		Console.WriteLine("Enter Age");
		s.age = Convert.ToInt32(Console.ReadLine());
		Console.WriteLine("Enter Marks");
		s.marks = Convert.ToInt32(Console.ReadLine());
		
		students[idx++] = s;
		Console.WriteLine("New Student Added");
		
	}
	
	public void BubbleSort(){
		if(idx==0){
			Console.WriteLine("No Students");
			return;
		}
		
		for(int i=0;i<idx-1;i++){
		
			bool isSort = true;
			for(int j=0;j<idx-1;j++){
				if(CompareString(students[j].name,students[j+1].name)){
					Student temp = students[j];
					students[j] = students[j+1];
					students[j+1] = temp; 
					isSort = false;
				}
				
			}
			if(isSort) break;
		}
		
	}
	
	public bool CompareString(string a,string b)
	{
		// a>b true
		// else false

		int len = Math.Min(a.Length,b.Length);
		int i=0;
		while (i < len)
		{
			if (a[i] > b[i]) return true;
        	if (a[i] < b[i]) return false;
		}

		if(a.Length>b.Length) return true;
		else false;
	}
	
	public void MergeSort(){
		if(idx==0){
			Console.WriteLine("No Students");
			return;
		}
		MergeSort(0,idx-1);
	}
	
	public void MergeSort(int i, int j){
		if(i>=j) return;
		int mid = (j+i)/2;
		MergeSort(i,mid);
		MergeSort(mid+1,j);
		
		Merge(i,mid,j);
	}
	
	public void Merge(int i,int mid,int j){
		int n1 = mid-i+1;
		int n2 = j-mid;
		
		Student[] s1 = new Student[n1];
		Student[] s2 = new Student[n2];
		
		for(int k=0;k<n1;k++) s1[k] = students[i+k];
		for(int k=0;k<n2;k++) s2[k] = students[mid+1+k];
		
		int a=0 , b = 0;
		int k = i;
		while(a<n1 && b<n2){
			if(s1[a].marks<=s2[b].marks)
			{
				students[k++] = s1[a++];
			}
			else{
				students[k++] = s2[b++];
			}
				
		}
		
		while(a<n1){
			students[k++] = s1[a++];
		
		}
		
		while(b<n2){
			students[k++] = s2[b++];
		
		}
	
	
	
	}
}

class StudentMenu{
	StudentUtilityImpl utility;

	
	public void Menu(){
	
		Console.WriteLine("Enter Capacity");
		int cap = Convert.ToInt32(Console.ReadLine());
		utility = new StudentUtilityImpl(cap);
		
		while(true){
			Console.WriteLine("1: Add Student");
			Console.WriteLine("1: Sort Student names(Bubble)");
			Console.WriteLine("3: Sort Student Marks(Merge)");
			Console.WriteLine("4: Exit");
			Console.WriteLine("option: ");
			int option = Convert.ToInt32(Console.ReadLine());
			
			switch(option){
				case 1 : utility.AddStudent();
					break;
				case 2 : utility.BubbleSort();
					break;
				case 3 : utility.MergeSort();
						break;
				case 4 : return;
				default : break;
			
			}
			
		}
		
	}
}

class StudentMain(){
	static void Main(){
		StudentMenu menu = new StudentMenu();
		menu.Menu();
	}

}
