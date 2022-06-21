using System.Threading.Tasks;

namespace SpectrumAssignment.Behaviors
{
    public interface IAction
    {
        Task<bool> Execute(object sender, object parameter);
    }
}