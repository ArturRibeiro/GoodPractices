namespace Pattern.Facade.Unit.Testing.Fakers
{
    public class GraphicsFacadeFaker : TheoryData<Action>
    {
        public GraphicsFacadeFaker()
        {
            var facade = new GraphicsFacade();
            Add(facade.DrawCircle);
            Add(facade.DrawSquare);
            Add(facade.DrawTriangle);
        }
    }
}