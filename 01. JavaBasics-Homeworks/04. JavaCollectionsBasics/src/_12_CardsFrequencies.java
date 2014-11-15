import java.util.ArrayList;
import java.util.Locale;
import java.util.Scanner;
 
public class _12_CardsFrequencies {
 
        public static void main(String[] args) {
               
                Locale.setDefault(Locale.ROOT);
                @SuppressWarnings("resource")
				Scanner input = new Scanner(System.in);
               
                String[] allCards = input.nextLine().split(" ");
                ArrayList<String> outputCards = new ArrayList<>();
                int[] cardsCounter = new int[13];
                double[] percents = new double[13];
                int allCardsCount = 0;
                for (int i = 0; i < allCards.length; i++) {                     
                        if(outputCards.contains(allCards[i])){                  
                                continue;
                        }
                        allCards[i] = allCards[i].substring(0, allCards[i].length() - 1);
                        outputCards.add(allCards[i]);
                }
               
                for(String card : allCards){                                            
                       
                        if(card.contains("A")){
                                cardsCounter[0]++;
                        } else if(card.contains("J")){
                                cardsCounter[10]++;
                        } else if(card.contains("Q")){
                                cardsCounter[11]++;
                        } else if(card.contains("K")){
                                cardsCounter[12]++;
                        }
                        for (int i = 2; i <= 10; i++) {
                                if(card.contains(i + "")){
                                        cardsCounter[i-1]++;
                                }
                        }
                }
               
                for(int count : cardsCounter){                                  
                        allCardsCount += count;
                }
               
                for (int i = 0; i < 13; i++) {                                  
                        if(cardsCounter[i] != 0){
                                double helper = (double)cardsCounter[i]/allCardsCount;
                                percents[i] = helper * 100;
                        }
                }
 
                for (int i = 0, j = 0; i < 13; i++) {                   
                        if(cardsCounter[i] != 0){
                                switch (outputCards.get(j)) {
                                case "A":
                                        System.out.printf("A -> %.2f%% \n", percents[0]);
                                        break;
                                case "2":
                                        System.out.printf("2 -> %.2f%% \n", percents[1]);
                                        break;
                                case "3":
                                        System.out.printf("3 -> %.2f%% \n", percents[2]);
                                        break;
                                case "4":
                                        System.out.printf("4 -> %.2f%% \n", percents[3]);
                                        break;
                                case "5":
                                        System.out.printf("5 -> %.2f%% \n", percents[4]);
                                        break;
                                case "6":
                                        System.out.printf("6 -> %.2f%% \n", percents[5]);
                                        break;
                                case "7":
                                        System.out.printf("7 -> %.2f%% \n", percents[6]);
                                        break;
                                case "8":
                                        System.out.printf("8 -> %.2f%% \n", percents[7]);
                                        break;
                                case "9":
                                        System.out.printf("9 -> %.2f%% \n", percents[8]);
                                        break;
                                case "10":
                                        System.out.printf("10 -> %.2f%% \n", percents[9]);
                                        break;
                                case "J":
                                        System.out.printf("J -> %.2f%% \n", percents[10]);
                                        break;
                                case "Q":
                                        System.out.printf("Q -> %.2f%% \n", percents[11]);
                                        break;
                                case "K":
                                        System.out.printf("K -> %.2f%% \n", percents[12]);
                                        break;
                                }
                                j++;
                        }
                       
                }
        }
 
}