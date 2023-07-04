namespace App.Web.Utils
{
    public static class TreeNodeHelper
    {

        public static IEnumerable<TreeNode<T>> FetchChildren<T>(this TreeNode<T> root, List<TreeNode<T>> nodes)
        {
            return nodes.Where(n =>
                n.ParentId is not null &&
                n.ParentId.Equals(root.Id));
        }

        public static void RemoveChildren<T>(this TreeNode<T> root, List<TreeNode<T>> nodes)
        {
            foreach (var node in root.Children)
            {
                nodes.Remove(node);
            }
        }

        public static TreeNode<T> BuildTree<T>(this TreeNode<T> root, List<TreeNode<T>> nodes)
        {
            if (nodes.Count == 0) { return root; }

            var children = root.FetchChildren(nodes).ToList();
            root.Children.AddRange(children);
            root.RemoveChildren(nodes);

            for (int i = 0; i < children.Count; i++)
            {
                children[i] = children[i].BuildTree(nodes);
                if (nodes.Count == 0) { break; }
            }

            return root;
        }
    }
}

