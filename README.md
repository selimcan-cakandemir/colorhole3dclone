# colorhole3dclone
Color Hole 3D Clone for Good Job Games

Scriptlerin içerisine bolca kodu açıklayan yorum satırları koydum fakat aşağıdada Unity projesinde olan organizasyon olsun, obje adları olsun, yaptığım öğeleri açıklayan notlar bırakıyorum. Eğer inceleyen teknik takımada bu notları gösterebilirsek çok sevinirim.

1.

Oyunun ana mekaniği olan "delik efektini", yeri temsil eden bir Quad içerisinde collider boşluğu yaratan bir daire collider'ı ile oluşturuyorum. Delik bir silindir ve oynatılınca Quad'ın üzerindeki 2 boyutlu yüzeyde hareket eden daire colliderını oynatıyor. Bu daire colliderıda Quad'ın üzerindeki objelerin düşmesi için bir alan oluşturuyor. Hirayerşideki ColliderTranslator'ın amacıda bu. Silindirin pozisyonunu circle collider ile eşleştirmek. Silindirin var olduğu 3D boyutu collider'ın var olduğu 2D'ye dönüştürmek. Bu sayede birini oynayınca diğeride oynamış oluyor.

Bu aşamanın basamak basamak kod anlatımı ColliderTranslator.cs script'i içerisindedir.

2.Seviyeler için basit bir design olsun diye farklı scene'ler kullanıyorum fakat Color Hole 3D oyununuzda aynı scene'in içerisinde birden fazla level var. Kullanılmayan ama yüklenmiş objelerde performans kazanmak için küplerin rigidbody'lerini layer aracılığı ile kapayıp, sadece deliğe yaklaştıklarında açıyorum.

Objeler aynı zamanda düştükten sonra Destroy() ile yok ediliyorlar.

3.Kontrol sistemi

Kontroller için kullandığım görsel asset paket: https://assetstore.unity.com/packages/p/joystick-pack-107631
