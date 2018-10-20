using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Concrete
{
    public class Repository
    {
        //实例化EF容器:有弊端。一个线程里可能会创建多个DbContext
        //DbContext db = new DbContext();

        //改造：保证一个请求线程中只有一份EF容器（你要明白：一个url请求到服务器，IIS就开一个线程去处理）
        public static EFDbContext GetDbContext
        {
            get
            {
                //向线程缓存中查询，如果返回的是null，则创建，同时存入到这个线程缓存中
                //注意的是线程缓存CallContext，而不是我们熟悉的HttpRuntime.cache。意味着这个DbContext对象在这个线程内能被其他方法共享。
                object efDbContext = CallContext.GetData("EFDbContext");
                if (efDbContext == null)
                {
                    efDbContext = new EFDbContext();
                    //存入到这个线程缓存中
                    CallContext.SetData("EFDbContext", efDbContext);
                }
                return efDbContext as EFDbContext;
            }
        }
    }
}
