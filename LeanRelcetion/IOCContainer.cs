using System.Diagnostics.Contracts;
using System.Reflection;

namespace LeanRelcetion;

public class IOCContainer
{
    Dictionary<Type, Type> _map = new Dictionary<Type, Type>();
    //MethodInfo? resolve;

    public void Register<TContract, TImplementation>()
    {
        if (!_map.ContainsKey(typeof(TContract)))
        {
            _map.Add(typeof(TContract), typeof(TImplementation));
        }
    }

    public void Register(Type contract, Type implementation)
    {
        if (!_map.ContainsKey(contract))
        {
            _map.Add(contract, implementation);
        }
    }

    public TContract Resolve<TContract>()
    {
        if (!_map.ContainsKey(typeof(TContract)))
        {
            throw new Exception("Doesnot contain this type");
        }

        return Create<TContract>(_map[typeof(TContract)]);
    }

    private TContract Create<TContract>(Type implementation)
    {
        //if (resolve == null)
        //{
        //    resolve = typeof(IOCContainer).GetMethod("Resolve");
        //}

        return (TContract)Activator.CreateInstance(implementation);
    }
}
