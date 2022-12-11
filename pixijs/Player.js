class Player extends PIXI.Sprite {
    constructor(px,py,texture,name,hp,speed,sx,sy){
      super(texture);
      this.anchor.set(0.5);
      this.name = name;
      this.x = px;
      this.y = py;
      this.hp = hp;
      this.speed = speed;
      this.scale.x = sx;
      this.scale.y = sy;
    }

    status() {
      return this.name
    }

    moveLeft() {
      this.x = this.x - this.speed * 1/app.ticker.FPS;
    }

    moveRight() {
        this.x = this.x + this.speed * 1/app.ticker.FPS;
      }
  }