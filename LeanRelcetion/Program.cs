
using LeanRelcetion;
using LearnRefletion;
using System.Reflection;
using System.Runtime.Remoting;


#region Reflection Part 1
//string name = "ilia";
//var type = name.GetType();
//Console.WriteLine(type);

//var typeo = typeof(string);
//Console.WriteLine(typeo);

//Assembly currentAssembly = Assembly.GetExecutingAssembly();
//Type[] types = currentAssembly.GetTypes();

//foreach (Type t in types)
//{
//    Console.WriteLine(t);
//}

//Console.WriteLine("Get Animal type");

//var animalType = currentAssembly.GetType("LeanRelcetion.Animal");

//foreach (var item in animalType.GetProperties())
//{
//    Console.WriteLine(item.Name);
//    Console.WriteLine(item.PropertyType);

//}

//Console.WriteLine("$$$$$$$$$$$$$$$$$ External Assembly $$$$$$$$$$$$$$$$$$");

//Assembly externalAssembly = Assembly.Load("Domain");
//Type[] domainTypes = externalAssembly.GetTypes();

//foreach(Type t in domainTypes)
//{
//    Console.WriteLine(t);
//}

//Console.WriteLine("$$$$$$$$$$$$$$$$$ AutoMapper Assembly $$$$$$$$$$$$$$$$$$");

////Assembly autoMapperAssembly = Assembly.Load("AutoMapper");
////Type[] autoMapperTypes = autoMapperAssembly.GetTypes();

////foreach (Type t in autoMapperTypes)
////{
////    Console.WriteLine(t);
////}



//Console.WriteLine("$$$$$$$$$$$$$$$$$ External Assembly Moduls $$$$$$$$$$$$$$$$$$");


//Module[] domainmodule = externalAssembly.GetModules();


//foreach (var item in domainmodule)
//{
//    Console.WriteLine(item);
//}



//Console.WriteLine("$$$$$$$$$$$$$$$$$ Animal Constructors $$$$$$$$$$$$$$$$$$");

//ConstructorInfo[] constructorInfos = animalType.GetConstructors();
//foreach (ConstructorInfo constructorInfo in constructorInfos)
//{
//    var parameterinfo = constructorInfo.GetParameters();

//    foreach (var pi in parameterinfo)
//    {
//        Console.WriteLine(pi.Name);
//        Console.WriteLine(pi.ParameterType);
//    }
//}

#endregion


//Animal dog = new Animal("pepe", 4, Breed.nagazi);

//Type dogType = dog.GetType();

//MethodInfo[] methodInfos = dogType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static );

//Console.WriteLine("############# Method Infos ###############################");
//foreach (MethodInfo methodInfo in methodInfos)
//{
//    Console.WriteLine(methodInfo);
//}


//FieldInfo[] fieldInfos = dogType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);

//Console.WriteLine("#################### Field Infos ############################");
//foreach (FieldInfo fieldInfo in fieldInfos)
//{
//    Console.WriteLine(fieldInfo);
//}


//Console.WriteLine("#################### Constructor Infos ############################");

//ConstructorInfo[] constructorInfos = dogType.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);

//foreach (var constructorInfo in constructorInfos)
//{
//    Console.WriteLine(constructorInfo);
//}

//Console.WriteLine("######### Invoke Animal ctor ########################");

//Type animalType =  typeof(Animal);

//ConstructorInfo animalConstructor = animalType.GetConstructor(BindingFlags.Instance | BindingFlags.Public, new Type[] { typeof(string), typeof(int) });


//Animal brown = (Animal)animalConstructor.Invoke(new object[] { "brown",3 });

//Console.WriteLine(brown);

//ConstructorInfo[] animalConstructors = animalType.GetConstructors(BindingFlags.Instance | BindingFlags.Public );


//Animal rex = (Animal)animalConstructors[0].Invoke(null);
//Animal tex = (Animal)animalConstructors[2].Invoke(new object[] {"Tex", 6, Breed.taqsa});

//Console.WriteLine(rex);
//Console.WriteLine(tex);


//Console.WriteLine("###################  Activator  #########################");

//ObjectHandle? mikiObjectHandler = Activator.CreateInstance("LeanRelcetion", "LearnRefletion.Animal");
//Animal miki = (Animal)mikiObjectHandler.Unwrap();
//Console.WriteLine(miki);


//Type AnimalTypeFromString = Type.GetType("LearnRefletion.Animal");
//Animal nes = (Animal)Activator.CreateInstance(AnimalTypeFromString, new object[] { "nes", 6, Breed.taqsa });
//Console.WriteLine(nes);

//ObjectHandle? chornaObjectHandler = Activator.CreateInstance("LeanRelcetion",
//                                                           "LearnRefletion.Animal",
//                                                           true,
//                                                           BindingFlags.Instance | BindingFlags.Public,
//                                                           null,
//                                                           new object[] { "chorna", 6, Breed.nagazi },
//                                                           null,
//                                                           null
//                                                           );
//Animal chorna = (Animal)chornaObjectHandler.Unwrap();

//Console.WriteLine(chorna);


IOCContainer iOCContainer = new IOCContainer();

iOCContainer.Register<IAnimalBehaivor, AnimalBehaivor>();

//var diType = iOCContainer.Resolve<IAnimalBehaivor>();

//diType.MakeSound();


//AnimalTrainer ilia = new AnimalTrainer(iOCContainer.Resolve<IAnimalBehaivor>());

//ilia.Train();


List<string> strings = new List<string>();

Console.WriteLine(strings.GetType());

var listGenericType = typeof(List<>);

var intListType = listGenericType.MakeGenericType(typeof(int));

var intList = (ICollection<int>)Activator.CreateInstance(intListType);

intList.Add(5);
foreach (var item in intList)
{
    Console.WriteLine(item);
}
