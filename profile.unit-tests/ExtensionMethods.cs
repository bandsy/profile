using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NSubstitute;

namespace profile.unit_tests
{
    public static class ExtensionMethods {
        public static DbSet<T> ToFakeDbSet<T> (this List<T> data) where T : class {

            var _data = data.AsQueryable ();
            var fakeDbSet = Substitute.For<DbSet<T>, IQueryable<T>> ();
            ((IQueryable<T>) fakeDbSet).Provider.Returns (_data.Provider);
            ((IQueryable<T>) fakeDbSet).Expression.Returns (_data.Expression);
            ((IQueryable<T>) fakeDbSet).ElementType.Returns (_data.ElementType);
            ((IQueryable<T>) fakeDbSet).GetEnumerator ().Returns (_data.GetEnumerator ());

            return fakeDbSet;
        }
    }

}