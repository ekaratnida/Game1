class Fruit extends PIXI.Sprite {

    constructor(px,py,texture,name,speed,sx,sy){
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
      this.y += this.speed;
    }
  }