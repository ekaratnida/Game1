class Fruit extends PIXI.Sprite {

    constructor(px,py,texture,name,speed,sx=1,sy=1){
      super(texture);
      this.anchor.set(0.5);
      this.name = name;
      this.x = px;
      this.y = py;
      this.speed = speed;
      this.scale.x = sx;
      this.scale.y = sy;
    }

    status() {
      return this.name
    }

    moveDown() {
      this.y += this.speed * 1/app.ticker.FPS;
    }
  }