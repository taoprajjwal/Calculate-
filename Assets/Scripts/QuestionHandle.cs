using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuestionHandle : MonoBehaviour {
	public Text Question;
	public static int Answer{ set; get; }

	 

	void Start () {

		Starting ();
	}

	public void Starting (){
		string Op = RandomOp ();
		int Num2 = RandomN (Op);
		int Num1 = RandomCond(Op,Num2);

		Question.text = Num1.ToString () + Op + Num2.ToString ();
		Calculation (Op, Num1, Num2);
		}






	public static int RandomN(string Op){
		int s=0;

		if(Op =="+"){
			s=Random.Range(4, MaxValuepmin(PlayerPrefs.GetInt("CurrentScore")));
		}
		if (Op == "-") {
			s = Random.Range (4, MaxValuepmin(PlayerPrefs.GetInt("CurrentScore")));
		}
		if (Op == "X") {
			s = Random.Range (4, MaxValueMultiply(PlayerPrefs.GetInt("CurrentScore")));
		}
		if (Op =="/"){
			s = Random.Range (4, MaxValueDivide(PlayerPrefs.GetInt("CurrentScore"))); 
		}

		return s;

	
	}

	public string RandomOp(){
		int s = Random.Range (1,5);
	 	if (s == 1) {
			return "+";

		}

		if (s == 2) {
			return "-";
		}

		if (s == 3) {
			return "X";
		} 

		if (s == 4) {
			return "/";
		} 

		else {
			return "...";
		}
	}

		
	public int RandomCond(string Opera,int Num){
		int Num2=0;	
		while (Num2 < Num) {
			Num2 = RandomN (Opera);
		}
		return Num2;
	}


	public void DisplayScore(int Num1,int Num2,string Op){

		Question.text = Num1.ToString () + Op + Num2.ToString ();

	}


	public static int MaxValuepmin(int Score){

		int s = (Score * 5) + 20;
		return s;
			
	}

	public static int MaxValueMultiply(int Score){

		return Score + 10;
	}

	public static int MaxValueDivide(int Score){
		int s = 100;
		if (Score % 5 == 0) {
			s = s + 50;
		}
		return s;
	}
	// Math Functions

	public  void Calculation(string Op,int Num1, int Num2){
		if (Op == "+") {
			AddFunction (Num1, Num2);}
		if(Op=="-"){	
			SubtractFunction(Num1,Num2);
		}
		if (Op == "X") {
			MultiplyFunction (Num1, Num2);}
		if (Op == "/") {
			DivideFunction (Num1, Num2);}
	}


	public void AddFunction(int A, int B){
		Answer = A + B;
	}

	public void SubtractFunction(int A, int B){
		Answer = A - B;
	}
	public void MultiplyFunction(int A,int B){
		Answer = A * B;
	}
	public void DivideFunction(int A,int B){
		int s = A % B;
		int UsedNum1=A;
		int UsedNum2=B;
		print (B);
		print (A);


		while(s!=0 || UsedNum1==UsedNum2){
			int Num2 = RandomN ("/");
			int Num1 = RandomCond("/",Num2);

			s = Num1 % Num2;
			UsedNum1 = Num1;
			UsedNum2 = Num2;

		}
		Answer = UsedNum1 / UsedNum2;
		DisplayScore(UsedNum1,UsedNum2,"/");

	}




}
