public class PigFactory
{
    private readonly PigViewFactory _pigViewFactory;
    private readonly ContainerPigUnit _containerPigUnit;

    public PigFactory(PigViewFactory pigViewFactory, ContainerPigUnit containerPigUnit)
    {
        _pigViewFactory = pigViewFactory;
        _containerPigUnit = containerPigUnit;
    }
    
    public PigUnit CreatePig()
    {
        ViewPigUnit viewPigUnit = _pigViewFactory.CreatePigView();
        PigUnit pigUnit = new PigUnit();
        pigUnit.UpdateView(viewPigUnit);
        
        _containerPigUnit.SetValue(pigUnit);
        return pigUnit;

    }
}