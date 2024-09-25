import {
  e
} from "./chunk.UZVKBFXH.js";
import {
  SlIcon
} from "./chunk.Y7EP3V6G.js";
import {
  watch
} from "./chunk.SJGTYGCD.js";
import {
  component_styles_default
} from "./chunk.K23QWHWK.js";
import {
  ShoelaceElement,
  n,
  r
} from "./chunk.UQRBALDC.js";
import {
  avatar_styles_default
} from "./chunk.GTZHBAAH.js";
import {
  x
} from "./chunk.CXZZ2LVK.js";
import {
  __decorateClass
} from "./chunk.625AWUY7.js";

// src/components/avatar/avatar.component.ts
var SlAvatar = class extends ShoelaceElement {
  constructor() {
    super(...arguments);
    this.hasError = false;
    this.image = "";
    this.label = "";
    this.initials = "";
    this.loading = "eager";
    this.shape = "circle";
  }
  handleImageChange() {
    this.hasError = false;
  }
  handleImageLoadError() {
    this.hasError = true;
    this.emit("sl-error");
  }
  render() {
    const avatarWithImage = x`
      <img
        part="image"
        class="avatar__image"
        src="${this.image}"
        loading="${this.loading}"
        alt=""
        @error="${this.handleImageLoadError}"
      />
    `;
    let avatarWithoutImage = x``;
    if (this.initials) {
      avatarWithoutImage = x`<div part="initials" class="avatar__initials">${this.initials}</div>`;
    } else {
      avatarWithoutImage = x`
        <div part="icon" class="avatar__icon" aria-hidden="true">
          <slot name="icon">
            <sl-icon name="person-fill" library="system"></sl-icon>
          </slot>
        </div>
      `;
    }
    return x`
      <div
        part="base"
        class=${e({
      avatar: true,
      "avatar--circle": this.shape === "circle",
      "avatar--rounded": this.shape === "rounded",
      "avatar--square": this.shape === "square"
    })}
        role="img"
        aria-label=${this.label}
      >
        ${this.image && !this.hasError ? avatarWithImage : avatarWithoutImage}
      </div>
    `;
  }
};
SlAvatar.styles = [component_styles_default, avatar_styles_default];
SlAvatar.dependencies = {
  "sl-icon": SlIcon
};
__decorateClass([
  r()
], SlAvatar.prototype, "hasError", 2);
__decorateClass([
  n()
], SlAvatar.prototype, "image", 2);
__decorateClass([
  n()
], SlAvatar.prototype, "label", 2);
__decorateClass([
  n()
], SlAvatar.prototype, "initials", 2);
__decorateClass([
  n()
], SlAvatar.prototype, "loading", 2);
__decorateClass([
  n({ reflect: true })
], SlAvatar.prototype, "shape", 2);
__decorateClass([
  watch("image")
], SlAvatar.prototype, "handleImageChange", 1);

export {
  SlAvatar
};
