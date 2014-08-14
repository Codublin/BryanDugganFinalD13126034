var cam1 : Camera  ;

var cam2: Camera ;

var cam3: Camera ;
 

 

function Start () {

cam1.enabled = true;

cam2.enabled = false;

 

 

yield WaitForSeconds(10);

cam1.enabled = false;

cam2.enabled = true;

 yield WaitForSeconds(10);

cam2.enabled = false;

cam3.enabled = true;

}

