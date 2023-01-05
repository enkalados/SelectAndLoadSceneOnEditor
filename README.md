# SelectAndLoadSceneOnEditor

![1](https://user-images.githubusercontent.com/69899473/210763962-91d0fa23-b29b-4d8e-8d29-4855dc275a4c.png)
Click space button on scene (editor)
Click to eye icon near to "Scene Loader Overlay"
![2](https://user-images.githubusercontent.com/69899473/210764439-1fc3ce87-3457-4e3d-bcb2-cd99aeb94403.png)
Then click and load scene you want.


**Add Your Scenes:**
SceneSelector>ShowScenes>
*menu.AddItem(new GUIContent(System.IO.Path.GetFileNameWithoutExtension(UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex(X))), colorIndex == A, () => colorIndex = A);*
x = your scene index
A = Item index
