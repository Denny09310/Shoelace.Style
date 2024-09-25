import {
  divider_styles_default
} from "./chunk.3BLTEGRR.js";
import {
  watch
} from "./chunk.SJGTYGCD.js";
import {
  component_styles_default
} from "./chunk.K23QWHWK.js";
import {
  ShoelaceElement,
  n
} from "./chunk.UQRBALDC.js";
import {
  __decorateClass
} from "./chunk.625AWUY7.js";

// src/components/divider/divider.component.ts
var SlDivider = class extends ShoelaceElement {
  constructor() {
    super(...arguments);
    this.vertical = false;
  }
  connectedCallback() {
    super.connectedCallback();
    this.setAttribute("role", "separator");
  }
  handleVerticalChange() {
    this.setAttribute("aria-orientation", this.vertical ? "vertical" : "horizontal");
  }
};
SlDivider.styles = [component_styles_default, divider_styles_default];
__decorateClass([
  n({ type: Boolean, reflect: true })
], SlDivider.prototype, "vertical", 2);
__decorateClass([
  watch("vertical")
], SlDivider.prototype, "handleVerticalChange", 1);

export {
  SlDivider
};
