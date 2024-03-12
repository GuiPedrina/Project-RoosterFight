using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEngine.GraphicsBuffer;

namespace Mecanica
{


    public class KnockBack : MonoBehaviour
    {

        private enum Size
        {
            direitaCima,
            direitaBaixo,
            EsquerdaCima,
            EsquerdaBaixo
        }
        private Size Direcoes;

        public float AnguloRadianos(Vector2 alvo, Transform PosicaoPlayer)
        {
            float Angulo = Mathf.Atan2(alvo.y - PosicaoPlayer.position.y,
                                       alvo.x - PosicaoPlayer.position.x);

            Vector2 VAngulo = new Vector2(Mathf.Cos(Angulo), Mathf.Sin(Angulo));

            return Angulo;

            //print("Radianos" + Angulo);
            //print("Vetor Angulo" + VAngulo);
        }

        public Vector2 AnguloVetor(Transform alvo, Transform PosicaoPlayer)
        {
            //float Angulo = Mathf.Atan2(alvo.y - PosicaoPlayer.position.y,
            //                           alvo.x - PosicaoPlayer.position.x);

            Vector2 Angulo = (alvo.position - PosicaoPlayer.position).normalized;

            Vector2 VAngulo  /*new Vector2(Mathf.Cos(Angulo), Mathf.Sin(Angulo))*/;

            return Angulo;

            //print("Radianos" + Angulo);
            //print("Vetor Angulo" + VAngulo);
        }

        public void lancar(GameObject personagem, Vector2 VAngulo, float forca, int vida, string tag)
        {

            if (VAngulo.x >= 0 && VAngulo.y >= 0)
            {
                Direcoes = Size.direitaCima;
                //print("//Direita - Cima");
            }
            //DireitA - Baixo
            else if (VAngulo.x >= 0 && VAngulo.y <= 0)
            {
                Direcoes = Size.direitaBaixo;
                //print("DireitA - Baixo");
            }
            //Esquerda - Cima
            else if (VAngulo.x <= 0 && VAngulo.y >= 0)
            {
                Direcoes = Size.EsquerdaCima;
                //print("Esquerda - Cima");
            }
            //Esquerda - Baixo
            else if (VAngulo.x <= 0 && VAngulo.y <= 0)
            {
                Direcoes = Size.EsquerdaBaixo;
                //print("Esquerda - Baixo");
            }



            if (tag == "Zhang")
            {
                if (Direcoes == Size.direitaCima)
                {
                    personagem.GetComponent<Rigidbody2D>().transform.Translate((new Vector2(personagem.transform.position.x + forca * (vida/100),
                                                                                      personagem.transform.position.y + forca * (vida / 100)) * VAngulo) * Time.deltaTime);
                    print(forca);
                }
                else if (Direcoes == Size.direitaBaixo)
                {
                    personagem.GetComponent<Rigidbody2D>().transform.Translate(new Vector2(personagem.transform.position.x + forca * (vida/100),
                                                                                      personagem.transform.position.y - forca * (vida / 100)) * VAngulo * Time.deltaTime);
                }
                else if (Direcoes == Size.EsquerdaCima)
                {
                    personagem.GetComponent<Rigidbody2D>().transform.Translate(new Vector2((personagem.transform.position.x - forca * (vida / 100)) * -VAngulo.x,
                                                                                        (personagem.transform.position.y + forca * (vida / 100)) * VAngulo.y) * Time.deltaTime);
                }
                else if (Direcoes == Size.EsquerdaBaixo)
                {
                    personagem.GetComponent<Rigidbody2D>().transform.Translate(new Vector2((personagem.transform.position.x - forca * (vida / 100)) * -VAngulo.x,
                                                                                        (personagem.transform.position.y - forca * (vida / 100)) * VAngulo.y) * Time.deltaTime);
                }
            }

           
            else if (tag == "Lele")
            {
                if (Direcoes == Size.direitaCima)
                {
                    personagem.GetComponent<Rigidbody2D>().transform.Translate((new Vector2(personagem.transform.position.x + forca * (vida / 100),
                                                                                      personagem.transform.position.y + forca * (vida / 100)) * VAngulo) * Time.deltaTime);
                    print(forca);
                }
                else if (Direcoes == Size.direitaBaixo)
                {
                    personagem.GetComponent<Rigidbody2D>().transform.Translate(new Vector2(personagem.transform.position.x + forca * (vida / 100),
                                                                                      personagem.transform.position.y - forca * (vida / 100)) * VAngulo * Time.deltaTime);
                }
                else if (Direcoes == Size.EsquerdaCima)
                {
                    personagem.GetComponent<Rigidbody2D>().transform.Translate(new Vector2((personagem.transform.position.x - forca * (vida / 100)) * -VAngulo.x,
                                                                                        (personagem.transform.position.y + forca * (vida / 100)) * VAngulo.y) * Time.deltaTime);
                }
                else if (Direcoes == Size.EsquerdaBaixo)
                {
                    personagem.GetComponent<Rigidbody2D>().transform.Translate(new Vector2((personagem.transform.position.x - forca * (vida / 100)) * -VAngulo.x,
                                                                                        (personagem.transform.position.y - forca * (vida / 100)) * VAngulo.y) * Time.deltaTime);
                }
            }

        }
    }
}
