namespace App.Web.Utils
{
    public class TreeNode<T>
    {
        public T Id { get; set; } = default!;
        public T? ParentId { get; set; }
        public string Name { get; set; } = default!;
        public List<TreeNode<T>> Children { get; set; } = new List<TreeNode<T>>();
    }
}

