using Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure
{
	public static class ObjectExtension
	{
		public static List<List<TStock>> SplitList(this List<TStock> list, int maxSize)
		{
			return list.Select((x, i) => new { Index = i, Value = x })
				.GroupBy(x => x.Index / maxSize)
				.Select(x => x.Select(v => v.Value).ToList()).ToList();
		}
	}
}
