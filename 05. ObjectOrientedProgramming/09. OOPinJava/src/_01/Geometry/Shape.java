package _01.Geometry;

public abstract class Shape {
	private Vertex[] vertices;

	public Shape(Vertex[] vertices) {
		this.setVertices(vertices);
	}

	public Vertex[] getVertices() {
		return vertices;
	}

	public void setVertices(Vertex[] vertices) {
		this.vertices = vertices;
	}
}
