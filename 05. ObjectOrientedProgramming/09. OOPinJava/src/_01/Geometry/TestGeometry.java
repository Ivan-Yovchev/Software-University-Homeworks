package _01.Geometry;

import java.util.Arrays;
import java.util.Comparator;
import java.util.List;
import java.util.stream.Collectors;

public class TestGeometry {

	public static void main(String[] args) {
		Vertex vertex1 = new Vertex2D(4, -5);
		System.out.println(vertex1);
		
		Vertex vertex2 = new Vertex2D(7, 8);
		System.out.println(vertex2);
		
		Vertex vertex3 = new Vertex2D(10, 12);
		System.out.println(vertex3);
		
		Shape triangle = new Triangle(new Vertex[]{ vertex1, vertex2, vertex3 });
		Shape rectangle = new Rectangle(new Vertex[]{ vertex1 }, 7, 8);
		Shape circle = new Circle(new Vertex[]{ vertex2 }, 8.54567);
		Shape pyramid = new SquarePyramid(new Vertex[]{ vertex1 }, 5, 9);
		Shape cuboid = new Cuboid(new Vertex[]{ vertex3 }, 3, 5, 4);
		Shape sphere = new Sphere(new Vertex[]{ vertex3 }, 1.17);
		
		Shape[] shapes = new Shape[] {
				triangle,
				rectangle,
				circle,
				pyramid,
				cuboid,
				sphere
		};
		
		for (Shape shape : shapes) {
			System.out.println(shape);
		}
		
		List<Shape> spaceShapes = 
				Arrays.asList(shapes)
				.stream()
				.filter(s -> s instanceof VolumeMeasurable)
				.filter(v -> ((VolumeMeasurable) v).getVolume() > 40)
				.collect(Collectors.toList());
		for (Shape shape : spaceShapes) {
			System.out.println(shape);
		}
		
		Comparator<Shape> perimeterComparator = 
				(Shape s1, Shape s2) -> Double.compare(
						((PlaneShape) s1).getPerimeter(), ((PlaneShape) s1).getPerimeter());
				
		List<Shape> planeShapes = Arrays.asList(shapes).stream()
				.filter(s -> s instanceof PlaneShape)
				.sorted(perimeterComparator)
				.collect(Collectors.toList());		
		for (Shape shape : planeShapes) {
			System.out.println(shape);
		}
	}
}
