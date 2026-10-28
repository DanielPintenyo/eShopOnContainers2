using System.ComponentModel.DataAnnotations;

namespace CatalogTCG.API.Model.CatalogItemDTO
{
    public class PaginatedItemsDTO<TEntity> where TEntity : class
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public long Count { get; set; }

        public IEnumerable<TEntity> Data { get; private set;}

        public PaginatedItemsDTO(int pageIndex, int pageSize, long count, IEnumerable<TEntity> data) 
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            Count= count;
            Data = data;
        }
    }
    public class CatalogItemDTO
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string CatalogType { get; set; }
        public string CatalogBrand { get; set; }
        public int AvailableStock { get; set; }

        public int RestockThreshold { get; set; }

        public int MaxStockThreshold { get; set; }

        public bool onReorder { get; set; }
    }
}
