using UnityEngine;

public class ColliderTranslator : MonoBehaviour {

    Mesh createdMesh;

    public PolygonCollider2D holeCollider2D; //köselere ula?mak için daire yerine polygon collider kullan?yoruz
    public PolygonCollider2D groundCollider2D;

    public Collider groundCollider;
    public MeshCollider createdMeshCollider;

    private void Start() {
        GameObject[] gameObjects = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        foreach (var gameObject in gameObjects) {
            if (gameObject.layer == LayerMask.NameToLayer("Objects")) {
                Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), createdMeshCollider, true);
            }
        }
    }

    //Fizik hesaplamalari yapacagimiz için her frame gelen Update() yerine fizik sistemini istikrarli araliklar ile çalisan bu metodu kullaniyoruz
    private void FixedUpdate() {
        if (transform.hasChanged == true) { //Hesaplamarimiz sadece hareket ettigimizde yaplsin diye bu sarti koyuyoruz
            transform.hasChanged = false; //hasChanged metodu false ve true arasindaki zaman farkini aliyor
            holeCollider2D.transform.position = new Vector2(transform.position.x, transform.position.z); //Silindir objesi 2 boyutlu olan delik colliderina baglaniyor
        }
        CreateColliderHole();
        Make3DCollider();
    }
    private void CreateColliderHole() { //Ground colliderinin içinde delik açmak için kullandigimiz metod.
        Vector2[] colliderPoints = holeCollider2D.GetPath(0);//holeCollider'in köseleri

        for (int i = 0; i < colliderPoints.Length; i++) {
            colliderPoints[i] += (Vector2)holeCollider2D.transform.position;//koseleri her frame aliyoruz
        }

        groundCollider2D.pathCount = 2;
        groundCollider2D.SetPath(1, colliderPoints);//holeCollider'in köselerini groundCollider'in içinde bosluk olacak sekilde yerlestiriyoruz
    }

    private void Make3DCollider() { //Bütün yeri kaplayan ama bosluga girmeyen 3D collider (3D objeler sadece 3D colliderlarla etkilesimde geçebiliyor)
        if (createdMesh != null) Destroy(createdMesh); //
        createdMesh = groundCollider2D.CreateMesh(true, true);
        createdMeshCollider.sharedMesh = createdMesh;
    }

    private void OnTriggerEnter(Collider other) { //Objeler kendi aralarinda ve ground ile carpismayi gormezden geliyor
        Physics.IgnoreCollision(other, groundCollider, true);
        Physics.IgnoreCollision(other, createdMeshCollider, false);
    }

    private void OnTriggerExit(Collider other) {
        Physics.IgnoreCollision(other, groundCollider, false);
        Physics.IgnoreCollision(other, createdMeshCollider, true);
    }

}
