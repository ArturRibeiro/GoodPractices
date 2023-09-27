using Pattern.Facade.ComplexSubsystem;

namespace Pattern.Facade
{
    public class GraphicsFacade
    {
        private Circle circle = new();
        private Square square = new();
        private Triangle triangle = new();

        public void DrawCircle() => circle.Draw();
        public void DrawSquare() => square.Draw();
        public void DrawTriangle() => triangle.Draw();
    }
}