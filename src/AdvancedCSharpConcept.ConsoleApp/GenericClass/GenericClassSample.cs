using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCSharpConcept.ConsoleApp.GenericClass
{
  public class GenericClassSample
  {


    // Repository Pattern tasarım desenleri geliştirken
    // Request and Respornse Pattern gibi desenler
    // Framework geliştirirken Base sınıfların tip bazlı tanımlaması
    public abstract class Entity<TKey>
      where TKey : IComparable // generic ifadelerin kısıtlanması
    {
      public TKey Id { get; set; }
    }

    public class Category : Entity<int>
    {
      public Category()
      {
        Id = 1;
      }
    }

    public class Product : Entity<Guid>
    {
      public Product()
      {
        Id = Guid.NewGuid();
      }
    }

    // Request Response Pattern
    // in yada out olduğunu sadece interface üzerinden berlitebiliriz.
    public interface IApplicationService<in TRequest, out TResponse>
      where TRequest : class, new()
      where TResponse : class, new()
    {
      TResponse Handle(TRequest request);
    }


    public class ProductCreateRequest
    {
      public string Name { get; set; }

    }

    public class ProductResponse
    {
      public int Id { get; set; }

    }

    public class ProductService : IApplicationService<ProductCreateRequest, ProductResponse>
    {
      public ProductResponse Handle(ProductCreateRequest request)
      {
        return default(ProductResponse);
      }
    }


    public interface IRepository<TEntity, TKey>
      where TEntity : Entity<TKey>
      where TKey : IComparable
    {

      void Create(TEntity entity);

    }

    public abstract class RepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey>
       where TEntity : Entity<TKey>
      where TKey : IComparable
    {
      public virtual void Create(TEntity entity)
      {
        Console.Out.WriteLine("Eklendi");
      }
    }


    public class ProductRepository : RepositoryBase<Product, Guid>
    {

      public override void Create(Product entity)
      {
        base.Create(entity);
      }

    }

    public class CategoryRepository : RepositoryBase<Category, int>
    {
      public CategoryRepository()
      {
      }

      public override void Create(Category entity)
      {
        base.Create(entity);
      }
    }

  }
}
