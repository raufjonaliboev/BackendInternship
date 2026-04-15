namespace projectingPatterns.Application.SOLID.ImprovedExample;

public class SolidImprovedExamples
{
    public void Run()
    {
        Console.WriteLine("Running SOLID Bad Examples...");
        SingleResponsibility singleResponsibility = new SingleResponsibility();
        singleResponsibility.Run();
    
        OpenClosed openClosed = new OpenClosed();
        openClosed.Run();
    
        LiskovSubstitution liskovSubstitution = new LiskovSubstitution();
        liskovSubstitution.Run();
    
        InterfaceSegregation interfaceSegregation = new InterfaceSegregation();
        interfaceSegregation.Run();
    
        DependencyInversion dependencyInversion = new DependencyInversion();
        dependencyInversion.Run();
    }
}