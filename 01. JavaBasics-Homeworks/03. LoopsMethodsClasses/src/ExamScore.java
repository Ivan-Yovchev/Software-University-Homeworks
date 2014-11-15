import java.util.ArrayList;
import java.util.Collections;
import java.util.Locale;
import java.util.Scanner;
import java.util.TreeMap;


public class ExamScore {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		Locale.setDefault(Locale.ROOT);
		
		for (int i = 0; i < 3; i++) {
			input.nextLine();
		}
		
		TreeMap<Integer, ArrayList<String>> examScore = new TreeMap<Integer, ArrayList<String>>();
		
		while(true){
			
			String inputLine = input.nextLine();
			if(inputLine.contains("-")){
				break;
			}
			else{
				String[] data = inputLine.split("[ |]+");
				Integer grade = Integer.parseInt(data[3]);
				
				if(examScore.keySet().contains(grade)){
					examScore.get(grade).add(data[1] + " " + data[2] + " " + data[4]);
				}
				else{
					ArrayList<String> temp = new ArrayList<>();
					temp.add(data[1] + " " + data[2] + " " + data[4]);
					examScore.put(grade, temp);
				}
			}
			
		}
		
		for (Integer grade : examScore.keySet()) {
			
			Collections.sort(examScore.get(grade));
			double avarege = 0;
			
			for (int i = 0; i < examScore.get(grade).size(); i++) {
				
				String[] getGrade = examScore.get(grade).get(i).split(" ");
				String name = getGrade[0] + " " + getGrade[1];
				examScore.get(grade).set(i, name);
				avarege += Double.parseDouble(getGrade[2]);
				
			}
			
			String formatGrade = String.format("%.2f", avarege/examScore.get(grade).size());
			
			System.out.println(grade + " -> " + examScore.get(grade) + "; avg=" + formatGrade);
			
		}
		
	}

}
