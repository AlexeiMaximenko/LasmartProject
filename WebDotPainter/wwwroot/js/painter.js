let getDotsPath = "/Data/GetDots/";
let deleteDotsPath = "/Data/DeleteDot/";
const request = new XMLHttpRequest();


paint(getDotsPath);

function paint(path){
    request.open('GET', path);
    request.setRequestHeader("Content-type", "application/json; charset=utf-8");
    request.send();
    request.addEventListener("load", () => {
            if (request.status == 200) {
                let data = JSON.parse(request.response);
                drawCircle(data);
            }
            else{
                console.log("Error. Request.status is not 200");
            }
        }
    );
};
function drawCircle(data){
    let stage = new Konva.Stage({
        height: 1200,
        width: 1200,
        container: "field",
    });
    let layer = new Konva.Layer();
    stage.add(layer);
    data.forEach(element => {
        let circle = new Konva.Circle({
            x: element.positionX,
            y: element.positionY,
            fill: element.color,
            radius: element.radius,
        });
        drawComment(element, layer);
        circle.addEventListener('dblclick', (e) => deleteElement(e, element))
        layer.add(circle);
    });
    layer.draw();
};

function drawComment(element, layer){
    let fntSize = 18;
    let fntPadding = 5;
    let margin = 5;
    element.comments?.forEach(com => {
            var text = new Konva.Text({
                text: com.text,
                fontSize: fntSize,
                padding: fntPadding,
                fill: 'black'
            });
            var tag = new Konva.Tag({
                fill: com.textAreaColor,
                stroke: 'gray'
            });

            var label = new Konva.Label({
                x: element.positionX - (text.width() / 2),
                y: element.positionY + element.radius + margin
            });

            
            label.add(tag);
            label.add(text);

            layer.add(label);
            margin += fntSize + 5 + fntPadding * 2;
        });
    };

function deleteElement(e, element){
    e.preventDefault();
    const request = new XMLHttpRequest();
    request.open('POST', deleteDotsPath);
    request.setRequestHeader("Content-type", "application/x-www-form-urlencoded; charset=utf-8");
    let sendableString = JSON.stringify(element);
    request.send(sendableString);
    request.addEventListener("load", () => {
        if (request.status == 200) {
            paint(getDotsPath);
        }
        else{
            console.log("Error. Request.status is not 200");
        }
    });
};