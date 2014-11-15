import java.io.FileOutputStream;

import com.itextpdf.text.BaseColor;
import com.itextpdf.text.Element;
import com.itextpdf.text.Document;
import com.itextpdf.text.Font;
import com.itextpdf.text.Paragraph;
import com.itextpdf.text.pdf.BaseFont;
import com.itextpdf.text.pdf.PdfPCell;
import com.itextpdf.text.pdf.PdfPTable;
import com.itextpdf.text.pdf.PdfWriter;

public class DeckOfCards {

	public static void main(String[] args) {
		
		Document document = new Document();
		try {
			
		PdfWriter.getInstance(document, new FileOutputStream("Deck-of-Cards"));
		document.open();
		
		String symbol = "";
		String suit = "";
		BaseFont font = BaseFont.createFont("arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
		Font black = new Font(font, 44f, 0, BaseColor.BLACK);
		Font red = new Font(font, 44f, 0, BaseColor.RED);
		
		//create 13 new tables holding 4 cards each
		for (int i = 0; i < 13; i++) {
			
			//determine cards
			if(i == 0){
				
				symbol = "A";
			}
			else if(i>=1 && i<=8){
				
				symbol = "" + (char)(49 + i);
			}
			else if(i == 9){
				
				symbol = "10";
			}
			else if(i == 10){
				
				symbol = "J";
			}
			else if(i == 11){
				
				symbol = "Q";
			}
			else if(i == 12){
				
				symbol = "K";
			}
			
			//create the table holding the cards
			PdfPTable table = new PdfPTable(4);
			PdfPCell cell = new PdfPCell();
			cell.setColspan(4);
			table.addCell(cell);
			
			for (int j = 0; j < 4; j++) {
				
				//determine suit
				if(j == 0){
					
					// spades
					suit = " " + "\u2663";
				
				}
				else if(j == 1){
					
					//clubs
					suit = " " + "\u2660";
				}
				else if(j == 2){
					
					//diamonds
					suit =" " + "\u2666";
				}
				else if(j == 3){
					
					//hearts
					suit = " " + "\u2665";
				}
				
				if(j<2){
					
					Paragraph p = new Paragraph((symbol + suit), black);
					cell = new PdfPCell(p);
				}
				else{
					
					Paragraph p = new Paragraph((symbol + suit), red);
					cell = new PdfPCell(p);
				}
				
				cell.setHorizontalAlignment(Element.ALIGN_CENTER);
				cell.setVerticalAlignment(Element.ALIGN_MIDDLE);
				cell.setFixedHeight(144f);
				table.addCell(cell);
				
			}
			
			table.setWidthPercentage(100);
			table.setSpacingAfter(12f);
			document.add(table);
			
		}
		} catch (Exception e) {
			
			System.out.println("Error");
		}
		document.close();

	}

}